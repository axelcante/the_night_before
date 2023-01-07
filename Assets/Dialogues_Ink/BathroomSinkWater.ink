VAR greg = 0

-> MAIN

=== MAIN ===
#player
Oh Lord what's that smell?
Penelope: No "Lord" at play here I'm afraid, just stupid kids that can't hold their liquor.
Penelope: And I thought my son was the worst adolescence could do...
{
    - greg == 0:
        -> CONTINUE
    - greg == 1:
        -> MET_GREG
}
-> DONE

=== MET_GREG ===
    + [You're Greg's mum??]
        -> CHALLENGE
    + [Say nothing]
        -> CONTINUE
-> DONE

=== CHALLENGE ===
Penelope: You've met my useless prop of a son?
Penelope: Well you must know then that he's a soft sop. Couldn't un-clog himself if his life depended on it...
#player
To be fair, it's not always that easy.
Penelope: I taught him to never rely on anyone but himself!
Penelope: After my Charlie left us... Taught him how life's a bully and doesn't grant wishes.
#player
...
#player
(Sounds like she's describing herself.)
Penelope: *sighs*
Penelope: You probably think I'm too hard on this kid...
Penelope: It's just been so <i>hard</i> without my Charlie...
Penelope: And I just can't get this stupid drain stopper out!
Penelope: Sometimes I wonder what the point of it all really is.
Penelope: Like, why go on?
-> CONTINUE

=== CONTINUE ===
#narrator
You stare at the murky water in disgust.
#narrator
You think you see something <i>moving</i>.
#player
Do you... do you need some help?
#narrator
As much as it is possible for a sink, Penelope looks you up and down disdainfully.
Penelope: You'd probably make things worse.
Penelope: ...
Penelope: But I suppose my lack of opposable thumbs, hands or even arms mean that I'm pretty much stuck.
Penelope: *sighs in frustration*
Penelope: *looking away* Whatever. See what you can do.
#narrator
With plenty of hesitation, you plunge your hand in the murky water, reaching up to your elbow.
#narrator
There <i>definitely</i> are things moving around in that water.
#narrator
You quickly find the drain stopper and pull it out.
#animate:BathroomSinkWaterSlideDown
Penelope: *breathes forcefully with relief*
Penelope: Fresh air at last!
Penelope: ...
Penelope: Thank you, stranger.
Penelope: You might not be so bad after all.
Penelope: Here. Someone from last night left this on me. I suppose it must've been precious, given they cracked down on the ground crying when they lost it.
#animate:SugarSlideUp
Penelope: Now leave me alone.
#player
Rude.
-> END