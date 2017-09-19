using System;

public enum  ImageCard
{    A,
     Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    K,
    Q,
    J
}

public enum Suit
{
    Spade = 0,
    Heart = 1,
    Club = 2,
    Diamond = 3
}

public enum StatusGame
{
    StartGame,
    Play,
    Win,
    Losing,
    GameOver,
    Draw
}
public enum CommandtGame
{
    StartGame,
    ClearBet,
    Deal,
    Hit,
    Stand,
    DoubleDown,
    Continue
}