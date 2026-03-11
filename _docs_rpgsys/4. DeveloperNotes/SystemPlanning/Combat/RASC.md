# Actions
#### Struct Attack Data
```
*TryDealDamage[]
	DamageType
	DamageAmmount

*TryApplyStatusCondition[]
	Status
	EModifier
	Value
	RequiresDamage (bool, se falso, o status não é aplicado quando o dano resultante é 0)
	SourceDamageType (tipo de dano relativo ao bool anterior, se nenhum for setado, aplica a todos)
	
*TryApplyActorCondition[]
	Reference FK Condicao
	RequiresDamage (bool, se falso, o status não é aplicado quando o dano resultante é 0)
	SourceDamageType (tipo de dano relativo ao bool anterior, se nenhum for setado, aplica a todos)
	
*OnAttackKills
*OnAttackMisses
*OnAttackHits
*AttackEffects (Efeitos Extras do ataque, o mesmo que ActorCondition mas para ataques)
```

#### Struct AttackCondition
```
// AttackCondition
// Enum de implementações hardcoded
props:
	source
	target
	attacker
onAttackHits()
onAttackMisses()
onAttackDealsNoDamage()
onAttackIsCritical()
onAttackKils()

afterTargetIdentified()
afterDamageCalc()
afterDamageApply()
afterAttackResolve()
```

#### Class Attacks
wrapper de action
```
```
#### Class Spells
wrapper de action
```
```
# Equipment

#### Enum WeaponTypes
Holdable?
```
```
#### Class Weapon
Implement [[4. DeveloperNotes/SystemPlanning/Inventory/RASC#Interface InventoryEquipment|Interface InventoryEquipment]]
```
```

#### Class Armour
Implement [[4. DeveloperNotes/SystemPlanning/Inventory/RASC#Interface InventoryEquipment|Interface InventoryEquipment]]
```
```

#### Class Ammunition
Implement [[4. DeveloperNotes/SystemPlanning/Inventory/RASC#Interface InventoryEquipment|Interface InventoryEquipment]]
```
```
