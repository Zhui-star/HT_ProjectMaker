using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
namespace HTLibrary.Application
{
    public struct Consts
    {
        public const string KeyWord="KeyWords";
    }

    
    /// <summary>
    /// 关键字数据库
    /// </summary>
    public class KeyWordDataBase :MonoSingleton<KeyWordDataBase>
    {
        //数据
        public List<string> keyWords = new List<string>();

        private void Awake()
        {
            LoadKeyWords();
        }

        /// <summary>
        /// 得到随机关键子
        /// </summary>
        /// <returns></returns>
        public string GetRandomKeyWord()
        {
            int randoIndex =UnityEngine.Random.Range(0, keyWords.Count);

            return keyWords[randoIndex];
        }

        /// <summary>
        /// 添加关键字
        /// </summary>
        /// <param name="keyword"></param>
        public void AddKeyWord(string keyword)
        {
            keyWords.Add(keyword);
        }

        /// <summary>
        /// 保存关键字
        /// </summary>
        void SaveKeyWords()
        {
            StringBuilder stringBuilder = new StringBuilder();

           foreach(var temp in keyWords)
            {
                stringBuilder.Append(temp);
                stringBuilder.Append(",");
            }


            PlayerPrefs.SetString(Consts.KeyWord, stringBuilder.ToString());
            PlayerPrefs.Save();
        }

        /// <summary>
        /// 加载关键字集合
        /// </summary>
        void LoadKeyWords()
        {
            if(PlayerPrefs.HasKey(Consts.KeyWord))
            {
               string tempStr= PlayerPrefs.GetString(Consts.KeyWord);
               string[] keyWords= tempStr.Split(',');
                
               foreach(var temp in keyWords)
                {
                    this.keyWords.Add(temp);
                }
            }
        }

        /// <summary>
        /// 返回关键字
        /// </summary>
        /// <returns></returns>
        public string[] GetKeyWords()
        {
            return keyWords.ToArray();
        }

       

        private void OnApplicationQuit()
        {
            SaveKeyWords();
        }
    }

}

