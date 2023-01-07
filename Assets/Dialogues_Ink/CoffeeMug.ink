VAR mug = 0

{
    - mug == 0:
        -> MAIN
    - mug == 1:
        -> ALREADY_HAVE
}

=== MAIN ===
#player
Phew, that was easy.
#player
Wonder who made this coffee and how it's still hot.
#player
...
#player
I don't have any roomates!
???: Sure about that?
#animate:CoffeeDrink
#player
...
#player
Who...
#player
What the f-
#player
Well, at least I can use this mug.
#variable:mug=1
#disable_object
#narrator
You found a <i>mug</i>!
-> END

=== ALREADY_HAVE ===
#player
Already got a mug.
-> END
