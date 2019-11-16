using System;

namespace ConsoleApp1
{
	public class RandomDataGenerator
	{
		public event EventHandler<RandomDataGeneratingEventArgs> RandomDataGenerating;
		public event EventHandler<RandomDataGeneratedEventArgs> RandomDataGenerated;

		public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{
			var result = new byte[dataSize];
			var rand = new Random();

			for (var i = 0; i < dataSize; i++)
			{
				result[i] = (byte) rand.Next(256);

				if ((i + 1) % bytesDoneToRaiseEvent == 0)
				{
					OnRandomDataGenerating(this, i + 1, dataSize);
				}
			}

			OnRandomDataGenerated(this, result);

			return result;
		}

		protected virtual void OnRandomDataGenerating(
			object sender,
			int bytes,
			int total)
		{
			var args = new RandomDataGeneratingEventArgs
			{
				BytesDone = bytes,
				TotalBytes = total
			};
			if (RandomDataGenerating != null)
			{
				RandomDataGenerating(sender, args);
			}
		}

		protected virtual void OnRandomDataGenerated(
			object sender,
			byte[] data)
		{
			var args = new RandomDataGeneratedEventArgs
			{
				RandomData = data
			};
			if (RandomDataGenerated != null)
			{
				RandomDataGenerated(sender, args);
			}
		}
	}
}