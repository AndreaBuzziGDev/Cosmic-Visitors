
ABOUT

This is a Project made during Level 1 of DBGA as a compulsory assignment.
It is based on the "Cosmic Visitors" game type assigned by our tutor.


In this game, you'll need to survive while being constantly attacked by enemy spaceship, which will come in sequential waves.
Spaceships travel at different speeds based on their type.

Each enemy has a chance to shoot you based on their type, they deliver damage if they collide with you 


ENEMY TYPES:

Base type enemies move slowly, but can shoot at you.
Fast type enemies move very fast, but cannot shoot you. They also are very fragile.
Asteroids move super slow, they will kill you on collision, are super resistant but are 100% guaranteed to drop loot on kill.

In general Red Enemies are more dangerous (more health, more bullets/faster).




WEAPONS & MECHANICS

You can only move upwards and downwards using W and S. 
Use it to dodge enemies and bullets, as well as to place yourself to damage enemies.

You have two weapons available: small cannons (spacebar) and a rocket launcher (R)

Small cannons deal very little damage, but are super fast and their ammo is infinite.
Rockets are a very limited resource, but they deal a lot of damage. You may find rocket ammo in loot crates dropped by the enemies.

You also have an energy shield that protects your spaceship's health. 
The shield protects to up to 3 units of damage and will always take damage first. Any excess damage on the shield will be transfered on the ships' health.

The shield will slowly start recharging if you don't receive damage for 7 seconds, but will only protect you from damage as long as it has recharged at least 1 unit of charge.

You can instantly replenish your health and shield with loot crates. Health won't go above 10 units and the shield won't go above 3.

When your health is completely depleted, your rocket ammo, health and shield are reset (3 ammo, 10 health, 3 shield charges).

When you die 3 times, the game is over.

You may pause the game with ESC.


CONTROLS (QUICK SUMMARY)

W - Move Up
S - Move Down
Spacebar - Shoot small cannons
R - Shoot rocket launcher
ESC - Pause


HOW TO PLAY

After retrieving the repository, open SampleScene and quick Play.




CUT FEATURES (No Time left)

- "Barrier" weapon
- "Thruster" weapon
- Rockets don't do Area of Damage.
- Leveling
- Bosses (& Boss Levels)
- Help panel in Menu
- Equipment change (Loot Crates will only refill Rocket Ammo, Health, Shield)
- Life regain (was supposed to be an asteroid-exclusive loot crate)



PERSONAL CONSIDERATIONS

I've spent quite a few sleepless nights on this. 

It's far from perfect, but it was quite a challenge and i can say i'm satisfied.

Some things i ran into:

- Unity doesn't like it if you define methods like Awake, Start and Update in a class and then re-declare them in a child class.
Ignoring this led to the MonoSingleton pattern not working at all (Awake method being overridden accidentally by child classes).

- Being very mindful of enums is super important.
I've used quite a lot of enums and if i had more time and foresight, i would have placed them somewhere else (like in a dedicated class).
What actually caused some pain and some waryness was that whenever a value was removed from an enum list, then changes could propagate to objects in the scene and prefabs, and those needed to be addressed.

- Static, Instances, and some other practical thingies
I'm not very used to working with instances of classes because on my job, unfortunately there is a massive usage of static code, or non-static code that eventually is programmed not that differently from static syntax.
This led to a lot of bias and pitfalls when designing code. I came through it, but it made me realize how despite coding a lot and having matured a lot of skills, eventually that skill might become a hindrance that influences way too much your creative process and thinking.
This challenge was a major test to overcome that.

- Sprite Editing
I think I either misunderstood entirely how to properly handle sprites, or I simply might have encountered some Unity Limitations.
Specifically, rotating sprites turned out to be way harder than i wished (no embedded feature in the sprite editor AFAIK), and led me to simply crop the sprites i needed and export them in a new file. I've read this is non-optimal, but this was the solution i could come up with that would not turn into an obstacle.
Another thing is that apparently whenever designing materials (like for Particle Effects), Unity will not let you use sprites extracted from a multi-sprite.
This also led to a lot of cropping.


- Crediting
I'm 100% i must have missed something in the credits.
This is why the crediting process, i believe, is something that must be handled immediately whenever necessary.
I will NEVER try to make posthumous credit again and start adding credits first.




