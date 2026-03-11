#### Abstract AttributeGroupSetter
Regra para aplicar um conjunto de modificadores de status
```
Abstract Class AttributeGroupSetter<AttributeGroup>
// Para cada status definido no grupo, define:
	float? nome_atributo // se nulo, não sobreescreve o valor base
	Modifiers[]? nome_atributo_modifiers // Se existir, aplica os modificadores no attributo
	
	AttributeGroup ApplyTo( AttributeGroup )
		// Aplica para cada atributo da entidade (tem que haver uma maneira de manter o valor original)
	
	AttributeGroup RemoveFrom( AttributeGroup )
		// Remove modificadores do grupo
```

#### Compound Action
[[Documentation/Core/Actions/RASC#Compound Action|Tambem disponivel aqui]]
Podemos adaptar essa estrutura de random para `Random<T>` nesse caso, `T` seria `IAction`
```
//Logica padrão de randomizacao
seed
Random:
	number of times chosen
	same result limit (int) // Numero maximo de vezes que um mesmo resultado pode ser escolhido. Se for negativo, permite duplicados sempre

RandomOutcomes[]:
	Results[] // um outcome pode ter multiplos resultados associados
	weight // int, probabilidade
	same result limit // Numero maximo de vezes que este resultado pode ser escolhido. Se for negativo, permite duplicados sempre, se for zero, sera sobreescrito com o valor de Random.same_result_limit 

```