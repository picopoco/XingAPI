﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using XingAPINet;

namespace XingAPINet
{
	public partial class XQt8426InBlock : XingBlock
	{
		/// <summary>
		/// t8426InBlock
		/// </summary>
		static readonly string _blockName = "t8426InBlock";
		/// <summary>
		/// 기본입력
		/// </summary>
		static readonly string _blockDesc = "기본입력";
		/// <summary>
		/// input
		/// </summary>
		static readonly string _blockType = "input";
		/// <summary>
		/// false
		/// </summary>
		static readonly bool _hasOccurs = false;
		/// <summary>
		/// t8426InBlock
		/// </summary>
		public override string GetBlockName() => _blockName;
		/// <summary>
		/// t8426InBlock
		/// </summary>
		public static string BlockName => _blockName;
		/// <summary>
		/// 기본입력
		/// </summary>
		public string BlockDesc => _blockDesc;
		/// <summary>
		/// input
		/// </summary>
		public string BlockType => _blockType;
		/// <summary>
		/// false
		/// </summary>
		public bool HasOccurs => _hasOccurs;

		/// <summary>
		/// Dummy
		/// </summary>
		[XAQueryFieldAttribute("Dummy")]
		public char dummy;

		public static class F
		{
			/// <summary>
			/// Dummy
			/// </summary>
			public const string dummy = "dummy";
		}

		public static string[] AllFields = new string[]
		{
			F.dummy,
		};


		public override Dictionary<string, XAQueryFieldInfo> GetFieldsInfo()
		{
			Dictionary<string, XAQueryFieldInfo> dict = new Dictionary<string, XAQueryFieldInfo>();
			dict["dummy"] = new XAQueryFieldInfo("char", dummy, dummy.ToString(), "Dummy", (decimal)1);

			return dict;
		}

		public override void SetFieldValue(string fieldName, XAQueryFieldInfo fieldInfo)
		{
			switch (fieldName)
			{
				case "dummy":
					this.dummy = fieldInfo.FieldValue.FirstOrDefault();
				break;


			}
		}

		public bool VerifyData()
		{
			// dummy char 1

			return true;
		}
	}

	public partial class XQt8426OutBlock : XingBlock
	{
		/// <summary>
		/// t8426OutBlock
		/// </summary>
		static readonly string _blockName = "t8426OutBlock";
		/// <summary>
		/// 주식종목마스터
		/// </summary>
		static readonly string _blockDesc = "주식종목마스터";
		/// <summary>
		/// output
		/// </summary>
		static readonly string _blockType = "output";
		/// <summary>
		/// true
		/// </summary>
		static readonly bool _hasOccurs = true;
		/// <summary>
		/// t8426OutBlock
		/// </summary>
		public override string GetBlockName() => _blockName;
		/// <summary>
		/// t8426OutBlock
		/// </summary>
		public static string BlockName => _blockName;
		/// <summary>
		/// 주식종목마스터
		/// </summary>
		public string BlockDesc => _blockDesc;
		/// <summary>
		/// output
		/// </summary>
		public string BlockType => _blockType;
		/// <summary>
		/// true
		/// </summary>
		public bool HasOccurs => _hasOccurs;

		/// <summary>
		/// 종목명
		/// </summary>
		[XAQueryFieldAttribute("종목명")]
		public string hname;
		/// <summary>
		/// 단축코드
		/// </summary>
		[XAQueryFieldAttribute("단축코드")]
		public string shcode;
		/// <summary>
		/// 확장코드
		/// </summary>
		[XAQueryFieldAttribute("확장코드")]
		public string expcode;

		public static class F
		{
			/// <summary>
			/// 종목명
			/// </summary>
			public const string hname = "hname";
			/// <summary>
			/// 단축코드
			/// </summary>
			public const string shcode = "shcode";
			/// <summary>
			/// 확장코드
			/// </summary>
			public const string expcode = "expcode";
		}

		public static string[] AllFields = new string[]
		{
			F.hname,
			F.shcode,
			F.expcode,
		};


		public override Dictionary<string, XAQueryFieldInfo> GetFieldsInfo()
		{
			Dictionary<string, XAQueryFieldInfo> dict = new Dictionary<string, XAQueryFieldInfo>();
			dict["hname"] = new XAQueryFieldInfo("char", hname, hname, "종목명", (decimal)20);
			dict["shcode"] = new XAQueryFieldInfo("char", shcode, shcode, "단축코드", (decimal)8);
			dict["expcode"] = new XAQueryFieldInfo("char", expcode, expcode, "확장코드", (decimal)12);

			return dict;
		}

		public override void SetFieldValue(string fieldName, XAQueryFieldInfo fieldInfo)
		{
			switch (fieldName)
			{
				case "hname":
					this.hname = fieldInfo.FieldValue.TrimEnd('?');
				break;

				case "shcode":
					this.shcode = fieldInfo.FieldValue.TrimEnd('?');
				break;

				case "expcode":
					this.expcode = fieldInfo.FieldValue.TrimEnd('?');
				break;


			}
		}

		public static XQt8426OutBlock[] ListFromQuery(XQt8426 query)
		{
			int count = query.GetBlockCount(XQt8426OutBlock.BlockName);
			List<XQt8426OutBlock> list = new List<XQt8426OutBlock>();
			if (query.QueryResult != null && query.QueryResult.IsSystemError == true)
			{
				return list.ToArray();
			}
			for (int i = 0; i < count; i ++)
			{
				XQt8426OutBlock block = new XQt8426OutBlock();
				block.IsValidData = true;
				block.InvalidReason = "";
				try
				{
					block.hname = query.GetFieldData(block.GetBlockName(), "hname", i).TrimEnd('?'); // char 20
					block.shcode = query.GetFieldData(block.GetBlockName(), "shcode", i).TrimEnd('?'); // char 8
					block.expcode = query.GetFieldData(block.GetBlockName(), "expcode", i).TrimEnd('?'); // char 12

				} catch (InvalidDataFormatException e) {
					block.IsValidData = false;
					block.InvalidReason = $"FieldName == {e.DataFieldName}, FieldData == \"{e.DataValue}\"";
				}
				list.Add(block);
			}
			return list.ToArray();

		}

		public bool VerifyData()
		{
			if (hname.Length > 20) return false; // char 20
			if (shcode.Length > 8) return false; // char 8
			if (expcode.Length > 12) return false; // char 12

			return true;
		}
	}

	public partial class XQt8426 : XingQuery
	{
		/// <summary>
		/// t8426
		/// </summary>
		static readonly string _typeName = "t8426";
		/// <summary>
		/// 상품선물마스터조회(API용)(t8426)
		/// </summary>
		static readonly string _typeDesc = "상품선물마스터조회(API용)(t8426)";
		/// <summary>
		/// 
		/// </summary>
		static readonly string _service = "";
		/// <summary>
		/// A
		/// </summary>
		static readonly string _headType = "A";
		/// <summary>
		/// 
		/// </summary>
		static readonly string _creator = "";
		/// <summary>
		/// 
		/// </summary>
		static readonly string _createdDate = "";
		/// <summary>
		/// false
		/// </summary>
		static readonly bool _attr = false;
		/// <summary>
		/// true
		/// </summary>
		static readonly bool _block = true;
		/// <summary>
		/// false
		/// </summary>
		static readonly bool _encrypt = false;
		/// <summary>
		/// false
		/// </summary>
		static readonly bool _signature = false;

		/// <summary>
		/// t8426
		/// </summary>
		public string TypeName => _typeName;
		/// <summary>
		/// 상품선물마스터조회(API용)(t8426)
		/// </summary>
		public string TypeDesc => _typeDesc;
		/// <summary>
		/// 
		/// </summary>
		public string Service => _service;
		/// <summary>
		/// A
		/// </summary>
		public string HeadType => _headType;
		/// <summary>
		/// 
		/// </summary>
		public string Creator => _creator;
		/// <summary>
		/// 
		/// </summary>
		public string CreatedDate => _createdDate;
		/// <summary>
		/// false
		/// </summary>
		public bool Attr => _attr;
		/// <summary>
		/// true
		/// </summary>
		public bool Block => _block;
		/// <summary>
		/// false
		/// </summary>
		public bool Encrypt => _encrypt;
		/// <summary>
		/// false
		/// </summary>
		public bool Signature => _signature;

		public XQt8426() : base("t8426") { }


		public bool SetFields(XQt8426InBlock block)
		{
			if (block.VerifyData() == false)
			{
				return false; // throw new ApplicationException("Failed to verify: " + block.BlockName);
			}

			_xaQuery.SetFieldData(block.GetBlockName(), "dummy", 0, block.dummy.ToString()); // char 1

			return true;
		}

		public XQt8426OutBlock[] GetBlocks()
		{
			XQt8426OutBlock[] instance = XQt8426OutBlock.ListFromQuery(this);
			return instance;

		}


	}

}