VAR blackestVoid = 0

{blackestVoid == 0:
    #animate:FadeToBlack
    #narrator
    The world darkens around you.
    #animate:Wait5Seconds
    #narrator
    Death's icy grips clutch at your soul.
    #animate:Wait5Seconds
    #narrator
    You feel your body slump lifelessly to the hard floor.
    #animate:Wait5Seconds
    #narrator
    ...
    #animate:FadeFromBlackQuick
    #animate:StopBlackestVoidMusic
    #variable:blackestVoid=1
    #narrator
    Actually you'll probably be fine.
    -> END
- else:
    #player
    Should probably not try that again...
    ->END
}