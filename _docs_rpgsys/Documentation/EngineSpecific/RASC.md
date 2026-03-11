
#### Interface InWorldEffect
Interface responsavel por mapear a transmição de dados referentes a acontecimentos graficos/funcionais dentro do mundo do jogo 
exemplo: 
	Explosão de um barril
	Começar a chover
 
> [!warning]
> Precisa ser contruida em runtime por conta das seguintes questões: 
> - Como eu faço para dinamicamente spawnar particulas de fogo quando o ataque é de fogo?
> - Como spawno uma criatura com stats relativos aos meus?). 
> 
> Podem ter templates na base de dados que serão sobreescritos em runtime

#### PrebuildInWorldEffect
```
// PrebuildInWorldEffect
// Grupo de onTargetEffects para facilitar o building de acoes. Imagino eu que qualquer acao tenha multiplos InWorldEffect.

Por exemplo:
	Explosão de fogo, é um effect que spawna 3 entidades (que normalmente são usadas juntas:
	uma bola de fogo, 
	particulas de fogo
	e uma textura de chamas no chão por alguns segundos
```

```
// InWorldEffect 

Target
*ScreenEffects
	// Parametros para afetar a camera

*TargetMove -
	Relative Direction (facing)
	Animation
	Distance
	VelocityFunc (enum easeIn / easeOut)
	funcStrength
	ThroughWalls   (bool)
	ThroughWatter  (bool)
	ThroughHoles   (bool)
	ThroughEnemies (bool)
	onColide (evento? enum?)

*TargetSpawnsEntity -        (lista?)
	Reference - FK para a entidade spawnada (objeto/critura actor? hitbox?)
	Relative Direction (facing)
	Is Position Binded To Parent (bool)
	Distance
	Random Offset (cria em algum lugar dentro da area)
	onCreateEffects // InWorldEffect (Particles, hitboxes)
	
	*On position Occupied - 
		maximum distance from origin
		BEHAVIOUR (enum)
			Ignore
			cancelAction
			Push
			ForcePush
	
	*Hitbox Configuration -
		onColide (evento? enum? presets?) //Presets:
			Ignore
			Stop
			Push
			ForcePush
			SwitchPlaces
			Jump	
		onColideCallFunc // (enum) Chama essa funcao para cada objeto que colidir
```