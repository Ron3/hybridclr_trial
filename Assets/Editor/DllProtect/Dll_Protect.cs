using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;
using System;
using UnityEditor.UnityLinker;
using System.Reflection;
using UnityEditor.Il2Cpp;
using Beebyte.Obfuscator;


namespace HuaTuo
{
    /// <summary>
    /// huatuo项目dll保护措施
    /// </summary>
    public class DllProtect
    {
        private static Options _options = null;

        public static string DllBuildOutputDir => Path.GetFullPath($"{Application.dataPath}/../HybridCLRData/HotFixDlls/");

        /// <summary>
        /// 获取dll所在的目录.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetDllBuildOutputDirByTarget(BuildTarget target)
        {
            return $"{DllBuildOutputDir}/{target}";
        }


        /// <summary>
        /// 测试入口
        /// </summary>
        [MenuItem("HybridCLR/DllProtect/Obfuscate")]
        public static void TestObfuscate()
        {
            DllObfuscate(EditorUserBuildSettings.activeBuildTarget);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void DllObfuscate(BuildTarget target)
        {
            string fullParentDirPath = GetDllBuildOutputDirByTarget(target);

            bool isObfuscatorSuccess = false;
            var dllPaths = new List<string> {Path.Combine(System.Environment.CurrentDirectory, $"{fullParentDirPath}/HotFix.dll"),
                                        Path.Combine(System.Environment.CurrentDirectory, $"{fullParentDirPath}/HotFix2.dll")
			};

            // 打印看一下.
			foreach (string dll in dllPaths)
			{
                UnityEngine.Debug.Log($"混淆dll ==> {dll}");

                if(File.Exists(dll) == false)
                    throw new Exception($"Could not find {dll}");
			}

			if (_options == null) 
            {
                _options = OptionsManager.LoadOptions();
            }
            // // 代码动态打开.默认是不要混淆的.防止不熟悉的人,直接用例子的时候,dll也被混淆了
            // _options.enabled = true;

			// bool oldSkipRenameOfAllPublicMonobehaviourFields = _options.skipRenameOfAllPublicMonobehaviourFields;
			try
			{
				// Preserving monobehaviour public field names is an common step for obfuscating external DLLs that
				// allow MonoBehaviours to be dragged into the scene's hierarchy.

				// by Ron 我们是需要混淆mono公共的变量名的.不能混淆的,都加标签
				// _options.skipRenameOfAllPublicMonobehaviourFields = true;

				// Consider setting this hidden value to false to allow classes like EditorWindow to be obfuscated.
				// ScriptableObjects would normally be treated as Serializable to avoid breaking loading/saving,
				// but for Editor windows this might not be necessary.
				// _options.treatScriptableObjectsAsSerializable = false;

				Obfuscator.SetExtraAssemblyDirectories(_options.extraAssemblyDirectories);
				Obfuscator.Obfuscate(dllPaths, _options, EditorUserBuildSettings.activeBuildTarget);

                isObfuscatorSuccess = true;
			}
			finally
			{
				// _options.skipRenameOfAllPublicMonobehaviourFields = oldSkipRenameOfAllPublicMonobehaviourFields;
                // _options.enabled = false;

                if(isObfuscatorSuccess == true)
                {
                    UnityEngine.Debug.Log($"混淆成功!");
                    EditorUtility.ClearProgressBar();
                }
			}
        }
    }
}
