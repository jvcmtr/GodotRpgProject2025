using System;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using Godot;

namespace DLL {

class TimerUtility
{
    public static double TimeWithProgress(Action<int> action, uint totalIterations, int progressInterval, bool showCurrentIteration = false, bool showPersent = false, string prefixTxt = "", string sufixTxt = "")
    {
        double totalTime = 0;
        int iteration = 0;
        var stopwatch = new Stopwatch();

        void printProgress(){
            var str = new StringBuilder()
                .Append(prefixTxt)
                .Append(ProgressBar((double)iteration / totalIterations, 30, showPersent))
                .Append( showCurrentIteration? $"  ({iteration}/{totalIterations})" : "");
            GD.PrintRaw($"\r{str}");
        };

        printProgress();
        GD.PrintRaw(sufixTxt);

        while (iteration < totalIterations)
        {
            stopwatch.Restart();

            for (int i = 0; i < Math.Min(progressInterval, totalIterations - iteration); i++)
            {
                action(iteration);
                iteration++;
            }

            stopwatch.Stop();
            totalTime += stopwatch.Elapsed.TotalSeconds;

            printProgress();
        }
        
        printProgress();
        
        return totalTime;
    }

    public static string ProgressBar(double progress, int resolution = 20, bool showPersent = false)
    {
        if (progress < 0 || progress > 1)
        {
            return "__ progress-bar-error __";
        }

        int complete = Int32.CreateChecked(progress * resolution);
        int head = progress == 1 ? 0 : 1;
        int incomplete = resolution - complete;

        var bar = new StringBuilder();
        bar.Append(new string('=', complete));
        if (head == 1) bar.Append("-");
        bar.Append(new string('_', incomplete));

        if(showPersent){ bar.AppendFormat(" {0:0.00}%", progress * 100);}
        return bar.ToString();
    }

    
}
}
