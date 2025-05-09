using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Xml.XPath;
using Godot;

namespace DLL {
    
    public class ComparativeTest<T> {
        public readonly string SUM = "_SUM";
        public readonly string AVG = "_AVG";

        public List<(string name, T)> Subjects;
        public List<(string name, Func<(T subject, int iteration), object> func)> Tests;
        public Table<TimeSpan> Results = new Table<TimeSpan>();
        public Dictionary<string, Func<(string subjectName, T subject, TimeSpan result), Table<TimeSpan>, string >> interpretations = new Dictionary<string, Func<(string subjectName, T subject, TimeSpan result), Table<TimeSpan>, string >>();
        public TimeSpan TotalTestDuration;

        public ComparativeTest(
            List<(string name, T subject)>? subjects = null, 
            List<(string name, Func<(T subject, int iteration), object> )>? tests = null 
        ){
            Subjects = subjects == null? new () : subjects ;
            Tests = tests == null? new () : tests;
        }

        public ComparativeTest<T> RunTests(uint iterations){
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            foreach (var sub in Subjects)
            {
                foreach (var test in Tests){
                    var dt1 = DateTime.Now;
                    for (int i = 0; i <= iterations; i++)
                    {
                        test.func.Invoke((sub.Item2, i));
                    }
                    var dt2 = DateTime.Now;
                    Results[sub.name, test.name] = dt2 - dt1; 
                }  
            }

            stopwatch.Stop();
            TotalTestDuration = TimeSpan.FromMilliseconds( stopwatch.Elapsed.TotalMilliseconds);
            return this;
        }

        public ComparativeTest<T> RunTestsWithProgress(uint iterations, bool showItems = false, bool showCurrentProcessing = false){
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            var total = Subjects.Count() * Tests.Count();
            var started = 0;
            
            foreach (var sub in Subjects)
            {
                foreach (var test in Tests){
                    started ++; 
                    
                    var a = new Action<int>( (i) => {test.func.Invoke((sub.Item2, i)); }); 
                    string sufix = (showItems? $" [{started}/{total}]" : "") +  (showCurrentProcessing? $" {sub.name}/{test.name}" : "");
                    var seconds = TimerUtility.TimeWithProgress(a, iterations, 20, false, false, "Progress: ", sufix + "              " );
                    
                    Results[sub.name, test.name] = TimeSpan.FromSeconds(seconds);
                }   
            }        
            GD.Print();

            stopwatch.Stop();
            TotalTestDuration = TimeSpan.FromMilliseconds( stopwatch.Elapsed.TotalMilliseconds);
            return this;
        }

        public ComparativeTest<T> IncludeSum(){
            foreach (var sub in Subjects)
            {
                Results[sub.name, SUM] = Results.GetAllCells()
                    .Where(c => c.Row == sub.name && c.Column != SUM && c.Column != AVG )
                    .Aggregate(TimeSpan.Zero, (sum, next) => sum + next.Value);
            }
            return this;
        }

        public ComparativeTest<T> IncludeAvg(){
            foreach (var sub in Subjects)
            {
                Results[sub.name, "_AVG"] = TimeSpan.FromTicks( (long)
                    Results.GetAllCells()
                    .Where(c => c.Row == sub.name && c.Column != SUM && c.Column != AVG )
                    .Average(c => c.Value.Ticks)
                );
            }
            return this;
        }

        public ComparativeTest<T> ClearInterpreters(){
            interpretations = new Dictionary<string, Func<(string subjectName, T subject, TimeSpan result), Table<TimeSpan>, string >>();
            return this;
        }

        public ComparativeTest<T> addTest(string name, Func<(T subject, int iteration), object> func, Func<(string subjectName, T subject, TimeSpan result), Table<TimeSpan>, string >? interpretation = null){
            Tests.Add((name, func));
            if(interpretation != null){
                interpretations[name] = interpretation;
            }
            return this;
        }

        public ComparativeTest<T> addInterpreter(string name, Func<(string subjectName, T subject, TimeSpan result), Table<TimeSpan>, string > interpretation ){
            interpretations[name] = interpretation;
            return this;
        }

        public ComparativeTest<T> AddSubject(string name, T subject){
            Subjects.Add((name, subject));
            return this;
        }
        
        public string GetFormatedResults(){
            Table<string> testIterpratations = new Table<string>();
            
            foreach (var cell in Results.GetAllCells())
            {
                string val = cell.Value.TotalMilliseconds + " ms";
                if( interpretations.TryGetValue(cell.Column, out var interpreter) ){
                    var subject = Subjects.First(s => s.name == cell.Row);
                    val = interpreter.Invoke((subject.name, subject.Item2, cell.Value), Results) ;
                }
                testIterpratations[cell.Row, cell.Column] = val;
            }

            return testIterpratations.GetFormated(" | ", ' ');
        }

        public TimeSpan GetTestOverhead(){
            IncludeSum();
            var testingTime = Results.GetAllCells().Where(c => c.Column == SUM).Sum(c => c.Value.TotalMilliseconds);
            return TimeSpan.FromMilliseconds(TotalTestDuration.TotalMilliseconds - testingTime);
        }
    }

    public class Table<T>   
    {
        private readonly Dictionary<(string row, string column), T> _data = new();

        public T this[string row, string column]
        {
            get
            {
                if (_data.TryGetValue((row, column), out var value))
                {
                    return value;
                }
                throw new KeyNotFoundException($"No entry found at row '{row}', column '{column}'.");
            }
            set
            {
                _data[(row, column)] = value;
            }
        }

        public bool TryGetValue(string row, string column, out T value)
        {
            return _data.TryGetValue((row, column), out value);
        }

        public bool Contains(string row, string column)
        {
            return _data.ContainsKey((row, column));
        }

        public IEnumerable<string> GetRows()
        {
            var rows = new HashSet<string>();
            foreach (var key in _data.Keys)
            {
                rows.Add(key.row);
            }
            return rows;
        }

        public IEnumerable<string> GetColumns()
        {
            var columns = new HashSet<string>();
            foreach (var key in _data.Keys)
            {
                columns.Add(key.column);
            }
            return columns;
        }

        public IEnumerable<(string Row, string Column, T Value)> GetAllCells()
        {
            foreach (var kvp in _data)
            {
                yield return (kvp.Key.row, kvp.Key.column, kvp.Value);
            }
        }

        public string GetFormated(string separator = "___|_", char spacer = '_')
        {
            string result = "";
            var cells = GetAllCells();

            var columns = _data.Keys.Select(key => key.column).Distinct().ToList();
            var rows = _data.Keys.Select(key => key.row).Distinct().ToList();
            var rowMaxLen = rows.Select(r => r.Length).Max();

            Dictionary<string, int> maxLengths = new Dictionary<string, int>();
            
            foreach(var cell in cells ){ 
                if(maxLengths.TryGetValue(cell.Column, out int existing)){
                    if (existing < cell.Value.ToString().Length){
                        maxLengths[cell.Column] = cell.Value.ToString().Length;
                    }
                }
                else{
                    var size = cell.Value.ToString().Length > cell.Column.Length ? 
                        cell.Value.ToString().Length 
                        : cell.Column.Length ;  
                    maxLengths[cell.Column] = size;
                }
            }

            string getCenteredValue(string value, int maxLen){
                return StringUtils.getCenteredValue(value.Replace(' ', spacer), maxLen, spacer);
            }

            string getLineBreak(){
                string r = "\n";
                return r;
            }

            // Add headers
            result += getCenteredValue("", rowMaxLen );
            result += separator;
            foreach (var column in columns)
            {
                result += getCenteredValue(column, maxLengths[column]);
                result += separator;
            }
            result += getLineBreak();

            // Add each entry
            foreach (var row in rows)
            {
                result += getCenteredValue(row, rowMaxLen );
                result += separator;
             
                foreach (var column in columns)
                {
                    result += getCenteredValue(this[row, column].ToString(), maxLengths[column]);
                    result += separator;
                }
                result += getLineBreak();
            }
            return result;
        
        }
    }

}
