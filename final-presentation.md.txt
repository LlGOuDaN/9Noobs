# 9 Noobs

Hi everyone I am Zhichao from 9 Noobs. I am presenting our 2D platform game today. Recall from the mid-term, we have the mechanism to switch the world. This can be used to both find blocks to step on or avoid barriers.

Now, according to the feedback from the mid-term, we will introduce 3 improvements on our game today: clearer goals, interactive items, and key-bind improvement.

To begin with, the clearer goals. The player cannot directly get the idea that the blue bar is the goal. And when the level becomes more complex, they may be confused about where to go since players have no clue about the direction of the exit. 

Especially in the second level, we can see many players missed the exit, which can be seen from the left bottom graph. Blue points are passing the red line, which means they passed the exit. This is because they have many ways to go and need to turn back to reach the exit in some cases. That is why this level is harder to pass and requires more attempts and have lower pass rate, according to the right graph.

To address this issue, we:
Clearly indicate the blue bar is the exit at very beginning tutorial so the player know this is their target.
Add a red arrow always pointing to the direction of the exit. So the player is not that easy to get lost.

Next, the interactive items.

According to the improvement plan collected from the mid-term form, 80% of the players want us to add more interactive items to increase playability. Therefore, we add two parts of interactive items, risks and rewards

For the risks:
We Add movable saw teeth so the player has to avoid them. The saw teeth move in a fixed pattern repeatedly.
Besides, we Add monsters. The monsters try to move toward the players. Players can kill them by stepping on the monsters.
For the rewards:
We Add coins to collect and a rating when completing the level. The rating is affected by the number of collected coins and some coins may require additional exploration to collect.

The coins, saw teeth, and monsters also adapt to our switching world logic so that they will only appear in the corresponding world. You have to explore the different world to collect coins and get high ratings.

Third, the key-bind.
About a quarter of players complains about they may easily confuse about the keys of detecting and switching. It is also observed during the class. Therefore, we combine the two operations into one key: switch the world by pressing the key and detect by long pressing the key.

We also add `esc` key to show the menu so the users can pause, return, or select menu by pressing the esc key.

Finally, let me present some demo plays of our game.

We also added BGMs and sound effects to our game. Hope you enjoy our game and thank you for the time!

## Links
[![Watch the video](https://img.youtube.com/vi/E9RrptYP_Kk/maxresdefault.jpg)](https://youtu.be/E9RrptYP_Kk)

[Figures used in final presentation](https://docs.google.com/presentation/d/1EGn_WpH4GPwtg3wJ7d-j6qMD4npteBwvHb7_2NbX59Y)

[Analytic document](https://docs.google.com/document/d/1hU1s7LIMh2wHtQMzcfWbVlf16A1XqiO_h9_E556EqV4/edit)

[Game design document](https://docs.google.com/document/d/1qXxPs-EgelTVCWomCqQQ3r2dnFMEJ2hRA7H6w89bmNI/edit#heading=h.sqt130g6wtrl)





