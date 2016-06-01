# BotClean Partially Observable

> The game Bot Clean took place in a fully observable environment, i.e., the state of every cell was visible to the bot at all times. Let us consider a variation of it where the environment is partially observable. The bot has the same actuators and sensors. But the sensors visibility is confined to its 8 adjacent cells.

You can find more about the problem [here](https://www.hackerrank.com/challenges/botcleanv2).

## My Solution

Because you can't see the entire board, it's best to store where you've already been, which is what I did here.

As I move through the board, I either:

- Select the closest dirty cell, OR
- Select the closest unknown area and work my way over