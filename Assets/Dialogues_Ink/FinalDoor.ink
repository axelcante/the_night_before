VAR questItems = 0

{
    - questItems == 4:
        -> THE_END
    - else:
        -> CANT_END
}

=== THE_END ===
#player
Alright, let's get this show on the road!
#player
I'm feeling absolutely fantastic!
#player
Ready to <i>kick</i> some <i>ass</i>.
#player
I can feel it in my bones, I'm about to be promoted.
#animate:FadeToBlack
#narrator
And the rest, as they say, is history.
#narrator
...
#animate:Wait3Seconds
#narrator
You were fired.
#animate:DisplayEndGame
#animate:Wait3Seconds
#animate:FadeEndGame
-> END

=== CANT_END ===
#player
Can't leave yet...
#player
Need my coffee before I can even set foot outside!
-> END