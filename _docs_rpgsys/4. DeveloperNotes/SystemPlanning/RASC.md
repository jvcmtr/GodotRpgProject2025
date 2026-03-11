
#### Classe Player
classe composta possui stats, inventario, sprite, skilltree, etc...

#### Struct ActorConditions
```
// Actor Conditions (passive/active effects)
// Enum de implementações hardcoded
onApply(target, sourceActor, sourceAction?)
onReapply(target, sourceActor, sourceAction?)
onTimePasses(target, deltaTime) //turno, counter etc...
onTargetDies(target)
onTargetActs(target, action)
onTargetIsActed(target, actor)
onUnapply(target)
```
