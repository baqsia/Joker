using Joker;
using Joker.Players;

var deck = new Deck();

var player1 = new Player("Bakar", 0);
var player2 = new Player("Giorgi", 1);
var player3 = new Player("Irakli", 2);
var player4 = new Player("Temo", 3);

deck.AcceptPlayer(player1)
    .AcceptPlayer(player2)
    .AcceptPlayer(player3)
    .AcceptPlayer(player4)
    .PrepareForStart()
    .Start();