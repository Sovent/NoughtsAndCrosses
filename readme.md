**Noughts and crosses API**
----
Элементы игрового поля представляют из себя перечисление Sign со значениями
```
enum Sign
{
  Noughts = -1,
  Empty = 0,
  Crosses = 1
}
```
Все запросы возвращают статус игры в формате:
```
{
  "gameId":<string>,
  "currentTurnPlayer":[string],
  "turnsCount":<int>,
  "crossesPlayer":<string>,
  "noughtsPlayer":<string>,
  "winnerRow":[[row0,column0],[row1,column1],[row2,column2]],
  "winnerPlayerName":[string],
  "field":[[<Sign>,<Sign>,<Sign>],[<Sign>,<Sign>,<Sign>],[<Sign>,<Sign>,<Sign>]]
}
```
Пример ответа:
```
{
  "gameId":"b9a6b0b4-2ca8-4c8a-a599-6678c15d2ad0",
  "currentTurnPlayer":"Max",
  "turnsCount":7,
  "crossesPlayer":"Steve",
  "noughtsPlayer":"Max",
  "winnerRow":[[0,0],[1,1],[2,2]],
  "winnerPlayerName":"Steve",
  "field":[[1,-1,-1],[0,1,-1],[0,1,1]]
}
```
* **Начать игру**

URL: /game

Method: POST

Body:
```
{
  "NoughtsPlayerName":<string>,
  "CrossesPlayerName":<string>
}
```
* **Посмотреть статус игры**

URL: /game/{gameId}

Method: Get

* **Сделать ход**

URL: /game/{gameId}/turn

Method: Post

Body:
```
{
  "PlayerName":<string>,
  "Row":<int>
  "Column":<int>
}
```
