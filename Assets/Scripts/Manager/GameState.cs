namespace BurgerBattler.Manager
{
    //ゲームの進行状態一覧
    public enum GameState
    {
        CharaSelect,
        BurgerCreate,
        BattleStart,
        Draw,
        PlayerTurn,
        PlayerCheck,
        EnemyTurn,
        EnemyCheck,
        Result
    }
}
