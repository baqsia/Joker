using System.Security.Cryptography;
using Joker;

var deck = new Deck();

var player1 = new Player("Bakar", 0);
var player2 = new Player("Giorgi", 1);
var player3 = new Player("Irakli", 2);
var player4 = new Player("Temo", 3);

deck.AcceptPlayer(player1);
deck.AcceptPlayer(player2);
deck.AcceptPlayer(player3);
deck.AcceptPlayer(player4);

deck.StartGame();