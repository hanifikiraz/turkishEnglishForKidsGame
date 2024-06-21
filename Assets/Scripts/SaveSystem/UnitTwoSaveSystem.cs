using Menu;
using UnityEngine;

namespace SaveSystem
{
    public class UnitTwoSaveSystem : MonoBehaviour
    {
        private LevelPlayButtonCustomization customButton;
        private bool isReplyLevel;
        private void OnEnable()
        {
            BusSystem.OnCustumazationButton += CustomButton;
            BusSystem.OnIncreaseLevel += LevelEnd;
            BusSystem.OnLevelReply += LevelReply;
        }

        private void OnDisable()
        {
            BusSystem.OnCustumazationButton -= CustomButton;
            BusSystem.OnIncreaseLevel -= LevelEnd;
            BusSystem.OnLevelReply -= LevelReply;
        }

        private void LevelReply(bool value)
        {
            customButton.LevelReply(true);
        }

        private void CustomButton(LevelPlayButtonCustomization value)
        {
            customButton = value;
            Debug.Log(value.gameObject.name);
        }

        private void LevelEnd()
        {
            Debug.Log(customButton.levelReply + "   LEvelRepplyy");
            if (customButton.levelReply == 0)
            {
                customButton.IncreaseLevel(); 
            }
        }
    }
}
