VAR blackestVoid = 0

{blackestVoid == 0:
    #narrator
    #animate:FadeToBlack
    The world darkens around you.
    #narrator
    #animate:Wait5Seconds
    Death's icy grips clutch at your soul.
    #narrator
    #animate:Wait5Seconds
    You feel your body slump lifelessly to the hard floor.
    #narrator
    #animate:Wait5Seconds
    ...
    #narrator
    #animate:FadeFromBlackQuick
    #animate:StopBlackestVoidMusic
    #variable:blackestVoid=1
    Actually you'll probably be fine.
    -> END
- else:
    #player
    Should probably not try that again...
    ->END
}