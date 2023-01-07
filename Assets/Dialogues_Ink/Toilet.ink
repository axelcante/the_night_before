-> MAIN

=== MAIN ===

#player
(Not very practical.)
Greg: *snifles*
#player
Hey...
#player
Are you okay?
Greg: I guess...
Greg: Life just sucks, you know?
#player
You're telling me.
#player
...
#player
What's got you down in the du-
#player
I mean, what's got you down?
Greg: I-... It's all these responsibilities...
Greg: This <i>pressure</i>...
Greg: The constant stress...
Greg: I just want to get away from it all...
#player
(What could be so stressful as a toilet?)
    + [... Tell me everything]
        -> OPENUP
    + [I mean... you're a toilet]
        -> ANGRY
    + [Get a grip!]
        -> SHOCKED

-> DONE

=== OPENUP ===

#player
(Here goes nothing.)
#player
Anything in particular you wanna talk about?
Greg: Where do I even start?
Greg: My mother... she keeps telling me I'm <i>piss</i> poor at everything I do...
Greg: My father never gave a <i>crap</i> about us, left when I was still a display unit...
Greg: My best friend is sick and the doctor's don't know what it is... turned him upside down!
Greg: Life is just all turning to <i>shit</i>, you know?
#player
Oh man, I feel you... brother (?).
#player
Hey listen... I've met a lot of toi-... people like you in this world.
#player
None of them compare.
#player
Your plumb- you're as strong as a brick wall.
#player
You shine brighter than a diamond... in the sky.
#player
And you're just <i>reliable</i>, you know? People can sit and talk to you whenever they feel like it.
#player
It's reassuring to have you around.
#player
Don't let anyone tell you otherwise.
#player
...
#narrator
If Greg had eyes, he would be looking at your through a whirlpool of tears.
Greg: *sniffles*
Greg: That... that's really nice of you to say.
Greg: *sniffles*
Greg: You're a good friend. Thank you for listening to me.
Greg: I'd like you to have this. My best friend gave it to me for a special occasion, but we never got around to using it.
Greg: And now that he's sick...
Greg: Well, I fell like you would make better use of it.
#variable:cocoaPowder=1
#narrator
You found <i>cocoa powder</i>!
#player
...
#player
(Do I want to know?)
#player
Thanks, man. You have a good day now. Keep your chi-... your seat up.
#narrator
You almost make out a smile under the toilet seat's gap.
#disable_script
Greg: *sniffles* You too, friend.

-> END

=== ANGRY ===

Greg: ...
Greg: *mute rage*
#disable_script
#narrator
The toilet drains itself of all its water. It will never fill up again.

-> END

=== SHOCKED ===

Greg: ...
Greg: *shocked silence*
Greg: You know... you're right!
Greg: I can't just sit around in my corner, grouching all day long.
Greg: There's a chance for all of out there, and it's up to us to go and take it!
Greg: *tentative sniffles*
Greg: And so what if you occasionally step in dog crap. Life goes on!
Greg: ...
Greg: Thank you. That was exactly what I needed to hear, I think.
Greg: I'd like you to have this. See you in another life, brother!
#animate:ToiletSlideDown
#variable:cocoaPowder=1
#narrator
You found <i>cocoa powder</i>!
#player
...
#player
How am I going to explain this to my landlord?

-> END