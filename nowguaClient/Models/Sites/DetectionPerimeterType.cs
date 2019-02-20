using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Models.Sites
{
	public class DetectionPerimeterType : LabelModel<int>
	{
		public int DistanceDeclaredCloseToArrived { get; set; }
		public int DistanceDeclaredArrived { get; set; }


		public DetectionPerimeterType(int Id, string Label, int DistanceDeclaredCloseToArrived, int DistanceDeclaredArrived)
			: base(Id, Label)
		{
			this.Label = Label;

			this.DistanceDeclaredArrived = DistanceDeclaredArrived;
			this.DistanceDeclaredCloseToArrived = DistanceDeclaredCloseToArrived;

		}
	}
}
