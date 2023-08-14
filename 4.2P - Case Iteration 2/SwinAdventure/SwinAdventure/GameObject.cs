using System;
namespace SwinAdventure
{
	public abstract class GameObject : IdentifiableObject
	{
		private string _description;
		private string _name;

		public GameObject(string[] ids, string name, string desc) : base(ids)
		{
			_name = name;
			_description = desc;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string ShortDescription
		{
			get
			{
				return $"{_name}: {FirstId}";
			}
		}

		public virtual string FullDescription { get { return _description; } }
	}
}

