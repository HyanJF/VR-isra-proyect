# VR Project
Este proyecto tiene como objetivo ser una prueba para un videojuego en Realidad Virtual (**VR**) con varias IAs con distintas funciones, asegurando una mejor experiencia al jugador.

## Introducción
El proyecto será un campo de tiros en VR, donde habrá 2 habitaciones con sus distinto objetivo. Una habitación será un campo de tiros donde el jugador va a tener una pista de obstáculos con dianas a las cuales tendrá que disparar para obtener puntos al mismo tiempo que tendrá que competir contra una IA. La otra habitación será una rango de apuntar donde el jugador tendrá que disparar a una IA adaptable.

## Habitaciones
### Campo de Tiros
Habitación con una pista de obstáculos con dianas y con un tiempo limitado para completar. En este, el jugador tendrá que completar la pista en el tiempo dado al mismo tiempo que podrá disparar a múltiples dianas para aumentar su puntaje. Estas dianas están controladas por un Game Master el cual va a modificar su spawn dependiendo de la habilidad del jugador.

Sin embargo, en esta habitación también va a haber una IA la cual va a competir contra el jugador. Esta también va a hacer la pista de obstáculos y disparar a las mismas dianas que el jugador, obteniendo su puntaje en lugar del jugador. Esto con el objetivo de obtener una mayor puntuación que el jugador.

### Shooting Range
Habitación con varios obstáculos y un dummy la cual va a ser el único objeto disparable. El objetivo de esta es dispararle al dummy y que este vaya adaptándose al jugador, huyendo y escondiéndose de él. Así, el jugador también va generando múltiples técnicas para obtener puntos.

<br></br>
## IAs
A continuación, se hablará más a detalle de cada IA dentro del proyecto:

### - Hyan
#### Game Master
<escribir aqui>

### - Gibran
#### Shooting range con dummy reaccionable
<escribir aqui>

### - Daniel
#### IA Competitiva
IA la cual estará en el campo de tiros, haciendo la pista de obstáculos junto al jugador. Se encargará de hacer la pista mientras que dispara a las dianas y obtiene una mayor puntuación que el jugador.
Se usará una IA con máquina de estados.
Su **estados** son los siguientes:
- Seguir Curso
- Perseguir Objetivo
- Disparar
- Buscar Objetivos

Sus **condiciones** son las siguientes:
- Detectó un Objetivo
- Puntuación del Jugador > Puntuación de IA
- Objetivo está Muerto
- Objetivo en Mira

  Con estos, el plan es el siguiente:
  - Empezar en **Seguir Curso**
    - Tener condición **Detectó un Objetivo**
  - Si condición es verdad **Perseguir Objetivo**
    - Tener condición **Objetivo en Mira**
  - Si condición es verdad **Disparar**
    - Tener condición **Objetivo está Muerto**
  - Si condición es verdad **Seguir Curso**
      - Tener condición **Puntuación del Jugador > Puntuación de IA**
    - Si condición es verdad **Buscar Objetivos**
      - Tener condición **Puntuación del Jugador > Puntuación de IA**
    - Si condición es falsa **Seguir Curso**

La IA va a empezar **siguiendo el curso**. Una vez que **detecte un objetivo**, irá por él hasta que entre a su **rango de disparo**. Una vez que pueda **disparar**, dispara hasta **destruir el objetivo**. Una vez destruido, va a checar si su **puntuación es mayor a la del jugador**. Si su puntuación es **mayor** a la del jugador, sigue con el curso. Si su puntuación es **menor** a la del jugador, va a buscar más objetivos hasta obtener una **mayor** puntuación que el jugador.
