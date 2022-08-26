// using NodeCanvas.Framework;
// using ParadoxNotion.Design;

using UnityEngine;
using HCLRGame;

/// <summary>
/// 这里有2种做法,可以选择跳过 HCRLTree 这个命名空间
/// 或者在类名上 [BPSkipRename] 这个标签.那么,类里面的成员就应该会被混淆的
/// </summary>
namespace HCRLTree
{
	// [Name("显示战场提示")]
	// [Description("显示战场提示")]
	// [Category(BPUtility.BP_BT_CATEGORY_PATH)]
	// public class BT_ShowTips : ActionTask{

    
    /// <summary>
    /// 因为我这里并没引入行为树插件,就大概给个示例代码吧.
    /// </summary>
    [BPSkipRename]
    public class BT_ShowTips
    {	
		// [Name("ID")]
		public int tipsId;

		// [Name("对话"), BPMultilingualText(1)]
		public string text;
		
		// [BPBTDisable, Name("对话 文本GUID"), BPMultilingualTextGUID(1)]
		public string textGUID = System.Guid.NewGuid().ToString("N");

		// [Name("位置")]
		// public BBParameter<Vector2> pos;


		// protected override string info 
        protected string info
        {
			get { return $"显示战场提示[{tipsId}]:{text}, 位置:pos";}
		}
		
        
		// Use for initialization. This is called only once in the lifetime of the task.
		// Return null if init was successfull. Return an error string otherwise
		// protected override string OnInit()
        protected string OnInit(){
			return null;
		}

		// public override void AfterDuplicate()
        public void AfterDuplicate()
		{
			textGUID = System.Guid.NewGuid().ToString("N");
		}

		// This is called once each time the task is enabled.
		// Call EndAction() to mark the action as finished, either in success or failure.
		// EndAction can be called from anywhere.
		// protected override void OnExecute()
        protected void OnExecute()
		{
			// EndAction(true);
		}

		// Called once per frame while the action is active.
		// protected override void OnUpdate()
        protected void OnUpdate()
		{
		}

		// Called when the task is disabled.
		// protected override void OnStop()
        protected void OnStop()
        {
			
		}

		//Called when the task is paused.
		// protected override void OnPause()
        protected void OnPause()
        {
			
		}
	}
}