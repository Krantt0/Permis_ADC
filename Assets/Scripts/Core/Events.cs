using UnityEngine.Events;

namespace Core
{
    public static class Events
    {
        public static UnityAction OnLoadPersistentControllers { get; set; }
        public static UnityAction OnLoadMainMenu { get; set; }
        public static UnityAction OnLoadQuiz { get; set; }
        public static UnityAction<int> OnAnswer { get; set; }
    }
}