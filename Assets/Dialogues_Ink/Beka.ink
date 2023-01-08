VAR questItems = 0
VAR cocoa = 0
VAR name = ""

-> MAIN

=== MAIN ===
{
    - questItems == 3:
        -> PROCEED
    - questItems == 4:
        -> BEKA
    - else:
        -> MISSING_ITEMS
}
-> END

=== PROCEED ===
#player
Hello, Beka.
#player
Can't tell you how happy I am to see you.
Beka: *grunts*
Beka: Whadaya want?
#player
I could really do with some of your strongest coffee, Beka. I'm close to dying here and I gotta get to work ASAP.
Beka: And that's my problem, how?
#player
...
#player
Look, can I just get a coffee please?
Beka: Sure. 15 bucks.
#player
What?! But it's my coffee!!
Beka: Oh yeah? Where's the coffee then, bucko?
#player
...
#player
(Shit, she's right.)
Beka: 30 bucks now.
#player
Okay, okay! Jeez...
Beka: Card or cash?
#player
What? I don't-
Beka: Look fellah, if you're just going to stand there I'm going to ask you to step aside and let other customers through.
#player
Other customers-
Beka: Ain't gonna repeat myself.
#player
But-
Beka: SECURITY! SECURITY!!
#player
C- Card, card!
Beka: ...
#animate:ToggleContactless
Beka: There you go.
#narrator
A little bit panicked, definitely freaked the shit out, you tap your phone to the contacless reader.
#player
Th- there.
#animate:ToggleContactless
Beka: Do you need the receipt?
#player
...
Beka: I'll take that as a no.
Beka: ...
Beka: Well? Mug, please.
#animate:ToggleBekaMug
#player
...
Beka: What's your name?
#player
Huh?
Beka: Gotta put a name on the mug. What's your name?
    + [I... I don't-]
        ~name="IDUNO"
        -> CONTINUE
    + [M-my name...?]
        ~name="MUMANAYME"
        -> CONTINUE
    + [Euh...]
        ~name="EUHE"
        -> CONTINUE
-> END

=== CONTINUE ===
Beka: ...
#animate:FillCoffee
Beka: ...
Beka: {name}! {name}!
Beka: ...
Beka: {name}, last call before I throw your coffee away!
#player
Uh yeah, yeah, that's me. (I think.)
Beka: You have a wonderful day, now, sir.
#animate:ToggleBekaMug
#player
Yeah... thanks.
#player
(Finally. The coffee.)
#animate:FadeToBlack
#narrator
With trembling anticipation, you put the "sugar" and milk in your coffee.
{
    - cocoa == 0:
        -> FINAL
    - else:
        -> COCOA
}
-> END

=== COCOA ===
#narrator
You even add the "cocoa" that Greg (the toilet) gave you earlier.
#narrator
Because why the hell not?
-> FINAL

=== FINAL ===
#narrator
Without taking the time to properly mix all the ingredients, you drink it all in one go.
#narrator
...
#player
Tastes weird.
#player
Tastes great!
#player
TASTES REALLY GOOD!
#animate:FadeFromBlackQuick
#animate:SkyDrugCrazyStart
#variable:beka=1
#player
TASTES REEEEEALLLLLLLLYFUCKINGGOOOOOOD!!!!
-> END

=== MISSING_ITEMS ===
#player
Don't have everything for coffee, yet.
#player
Let's see...
#player
I need a mug.
#player
Sugar. Can't have coffee without sugar.
#player
And milk. I'm not 50 years old yet to drink black coffee.
#player
...
#player
No offense to anyone who can hear this.
#player
(Which I hope is nobody.)
-> END

=== BEKA ===
#player
YYYYYYYYYYYYYYYYEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAHHHHHHHH
-> END