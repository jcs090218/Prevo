#if UNITY_EDITOR
/**
 * Copyright (c) 2020 Federico Bellucci - febucci.com
 * Copyright (c) 2021 Jen-Chieh Shen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software/algorithm and associated
 * documentation files (the "Software"), to use, copy, modify, merge or distribute copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * - The Software, substantial portions, or any modified version be kept free of charge and cannot be sold commercially.
 * 
 * - The above copyright and this permission notice shall be included in all copies, substantial portions or modified
 * versions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 * For any other use, please ask for permission by contacting the author.
 */
using UnityEditor;

namespace Prevo
{
    [System.Serializable]
    public class PrevoData : PrevoComponent
    {
        /* Variables */

        public bool updateInPlayMode = true;
        public bool updateInPrefabIsoMode = true;

        public Data_Preview preview = new Data_Preview();

        public const bool f_preview = true;

        /* Setter & Getter */

        public static PrevoData instance { get { return PrevoPreferences.data; } }

        /* Functions */

        public override string FormKey(string name) { return PrevoUtil.FormKey("root.") + name; }

        public override void Init()
        {
            ExecuteAll(PrevoComponentFunctions.INIT);
        }

        public override void Draw()
        {
            ExecuteAll(PrevoComponentFunctions.DRAW);
        }

        public override void SavePref()
        {
            ExecuteAll(PrevoComponentFunctions.SAVE_PREF);
        }

        private static void Execute(PrevoComponent hc, PrevoComponentFunctions fnc, bool flag)
        {
            if (!flag)
                return;

            switch (fnc)
            {
                case PrevoComponentFunctions.INIT: hc.Init(); break;
                case PrevoComponentFunctions.DRAW: hc.Draw(); break;
                case PrevoComponentFunctions.SAVE_PREF: hc.SavePref(); break;
            }
        }

        private void ExecuteAll(PrevoComponentFunctions fnc)
        {
            Execute(preview, fnc, f_preview);
        }
    }
}
#endif
