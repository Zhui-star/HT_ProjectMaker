using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HTLibrary.Application
{
    /// <summary>
    /// 游戏制造UI面板
    /// </summary>
    public class GameMakePanel : MonoBehaviour
    {
        public Text[] keyWordTxts;
        bool roll = false;
        public Button rollBtn;
        public InputField inputKeyWord;
        public GameObject storeSuccessFeddback;
        public Text showAllKeyWordTxt;
        private void Start()
        {
            InvokeRepeating("ProcessKeyWord", 0, 0.1f);
            UpdateKeyWordTxt();
        }

        /// <summary>
        /// 得到随机关键字
        /// </summary>
        void ProcessKeyWord()
        {
            if (roll)
            {
                foreach (var temp in keyWordTxts)
                {
                    temp.text = KeyWordDataBase.Instance.GetRandomKeyWord();
                }
            }
        }

        /// <summary>
        /// 开始随机关键字
        /// </summary>
        public void StartRandomKeyWord()
        {
            roll = true;
            rollBtn.interactable = false;
            Invoke("StopProcess", 10.0f);
        }

        /// <summary>
        /// 停止关键字
        /// </summary>

        void StopProcess()
        {
            roll = false;
            rollBtn.interactable = true;
        }

        /// <summary>
        /// 存储关键字
        /// </summary>
        public void StoreKeyWord()
        {
            string tempKeyWord = inputKeyWord.text;
            KeyWordDataBase.Instance.AddKeyWord(tempKeyWord);
            storeSuccessFeddback.SetActive(true);
            UpdateKeyWordTxt();
        }

        /// <summary>
        /// 更新已有关键字
        /// </summary>
        void UpdateKeyWordTxt()
        {
            string[] keyWords= KeyWordDataBase.Instance.GetKeyWords();

            showAllKeyWordTxt.text= "已有关键字 \n";

            foreach(var temp in keyWords)
            {
                showAllKeyWordTxt.text += temp;
                showAllKeyWordTxt.text += "\n";
            }
        }

        public void ApplicationQuitClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
UnityEngine.Application.Quit();
#endif
          
        }

    }

}
