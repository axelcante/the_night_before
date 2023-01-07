VAR doorBedKey = 0

{
    - doorBedKey == 0:
        -> DoorLocked
    - doorBedKey == 1:
        -> DoorUnlocked
}

=== DoorLocked===
#animate:DoorShake
#player
This door is locked??
#player
Help!
#player
...
#player
SOMEBODY HELP!
Door: Quit yar yappin', fella, some of us be tryna sleep, right?!
Door: Any idea what time it is?
#player
...
#player
I'd like to get out of... <i>my</i>... bedroom.
Door: Not possible, laddy.
#player
Why not?
Door: Think hard.
#player
...
Door: Not the sharpest tool in the toolbox, are ye now?
#player
...
Door: Not the prettiest mirror in the mall?
#player
...
Door: Not the heaviest weight in the gym?
#player
...
#player
What?
Door: Ye ever open a door without a key, lad?
#player
... Actually, yes I have.
Door: ...
Door: WELL THIS DOOR AIN'T ONE OF THOSE.
#player
But you don't even have a keyhole.
Door: Maybe there be different types of keys, ey?
Door: Like...
#player
...
#player
Like...?
Door: LIKE POLITNESS AND MAGIC WORDS, YA GALLYWAG!
#player
...
    + [Please, can you open?]
        -> OpenDoor
    + [Oh f- off, you plank of wood]
        -> HideDoor
        
=== OpenDoor ===
Door: Well then.
Door: Wasn't so hard, wadn't it?
#player
...
#animate:OpenCloseDoor
#variable:doorBedKey=1
Door: *hmmph*
-> END

=== HideDoor ===
Door: Well, ain't that just great.
Door: You enjoy your doorless pit of a bedroom, then.
Door: ...
#animate:DoorSlideDown
Door: Skunk.
#player
...
#player
Good riddance.
-> END

=== DoorUnlocked ===
~ temp randNum = RANDOM(1,4)
{
    - randNum == 1:
        #animate:OpenCloseDoor
        Door: *snores* Wha--?
        Door: *snores*
    - else:
        #animate:OpenCloseDoor
        Door: *snores*
}
-> END
