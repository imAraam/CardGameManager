# CardGameManager

## Note:
- Made using Visual Studio 2019, .NET 4.8.
- This library was developed with the Go Fish game in mind which resulted in some specialised methods to manage the game. 


## Instructions:
To use the library as a reference, download the .dll file found in the DownloadMe folder, add the reference to your project, and then add  "using CardGameManager;" to your .cs file.

## Structure breakdown:
### <ins>Entities</ins>
<dl>
  <dt>Card.cs</dt>
  <dd>Each card entity has a rank and suit.</dd>
  <dt>Deck.cs</dt>
  <dd>Contains a list of cards, each deck of cards equals 52 without Jokers. Instantiation of object creates x number of deck cards and shuffles them. Deck class manipulates deck cards only. </dd>
  <dt>Hand.cs</dt>
  <dd>Contains list of cards.</dd>
  <dt>Players.cs</dt>
  <dd>Contains hand of cards. Player class manipulates cards in Hand class and interactes with cards in other player objects. Is also responsible for keeping track of player points.</dd>
</dl>	

### <ins>Enums</ins>
<dl>
  <dt>EnumDefinitions.cs</dt>
  <dd>Includes enum of ranks Ace to Joker and enum of suits Hearts, Clubs, Diamonds, Spades.</dd>
</dl>	


## Example Pseudo code Go Fish game loop:
    Player1 = new Player()
    Player2 = new Player()
    Deck = new Deck()
    Deck.DealTo(Player1, 5)
    Deck.DealTo(Player2, 5)

    While(game)
      If (player1.AskForRank(Player2, randomRank))
        Player1.TakeMatchingCards(Player2, Player1, randomRank)
      Else
        Deck.Draw(Player1)
        If (Player1.IsLastCardDrawnGoFish(randomRank))
          "Show card to player2"
			
      If (Player1.HasFourOrMoreDuplicates())
        Player1.PlaceDownDuplicates()
        Player1.AddPoints(1)
        If (Deck.IsEmpty && Player1.Hand.Cards.Count == 0)
          "I win!"

      //Repeat with player2 ---
