using System;
using UnityEngine;

namespace HCLRGame
{
	// 跳过整一段, 连函数参数/内容都应该不会被混淆
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Event | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Delegate)]
	public class BPSkipAttribute : System.Attribute
	{
		public BPSkipAttribute()
		{

		}
	}

    // 不混淆函数名字,参数/内容都混淆.一般情况下都使用这个
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Event | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Delegate)]
	public class BPSkipRenameAttribute : System.Attribute
	{
		public BPSkipRenameAttribute()
		{
			
		}
	}

 	//  这个跟上面一样.可能大家用习惯了.那就继续用这个吧
    // public class DoNotRenameAttribute : System.Attribute
    // {
    //     public DoNotRenameAttribute()
    //     {
    //         
    //     }
    // }

	
	// 将某个函数/类名,重命名参数指定的
	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface|AttributeTargets.Struct|AttributeTargets.Method|AttributeTargets.Enum|AttributeTargets.Field|AttributeTargets.Property|AttributeTargets.Delegate)]
	public class BPRenameAttribute : System.Attribute
	{
		private readonly string target;
		
		private BPRenameAttribute()
		{
		}

		public BPRenameAttribute(string target)
		{
			this.target = target;
		}
		
		public string GetTarget()
		{
			return target;
		}
	}
	
	public class BPEnumLabelAttribute : HeaderAttribute
	{
		public BPEnumLabelAttribute(string header) : base(header)
		{
		}
	}
	
	public class BPExpandableAttribute : PropertyAttribute
	{
		public BPExpandableAttribute()
		{

		}
	}
	
	public class BPLabelAttribute : PropertyAttribute
	{
		public string label;
		public BPLabelAttribute(string label)
		{
			this.label = label;
		}
	}
	
}
