using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models
{
	/// <summary>
	/// Id + Name
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class NameModel<T>
	{
		public T Id { get; set; }
		public string Name { get; set; }
	}
}
