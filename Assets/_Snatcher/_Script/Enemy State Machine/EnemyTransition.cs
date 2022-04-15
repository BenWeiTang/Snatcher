namespace Snatcher
{
    [System.Serializable]
    public class EnemyTransition
    {
        public ADecision Decision;
        public AEnemyState TrueState;
        public AEnemyState FalseState;
    }
}