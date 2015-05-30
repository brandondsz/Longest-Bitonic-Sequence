using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitonicSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I will find the length of the largest Bitonic Sequence\n\nInput sequence seperated by a whitespace:");
            var inp=Console.ReadLine();
            string[] stringSeq = inp.Split(' ');
            List<long> numSeq=new List<long>();
            stringSeq.ToList().ForEach(x => numSeq.Add(Int64.Parse(x)));

            List<theDataStructure> list = new List<theDataStructure>();
            int maxLength = 0;
            foreach (var num in numSeq)
            {
                var length = list.Count;
                list.Add(new theDataStructure() { threshold = false, Sequence = new List<long>() { num } });
                for (int i = 0; i < length; i++)
                {
                    if (list[i].Sequence.LastOrDefault() < num && !list[i].threshold) 
                    {
                        //Add an new sequence with the new num
                        list.Add(new theDataStructure() { Sequence = new List<long>(list[i].Sequence), threshold = false });
                        list.LastOrDefault().Sequence.Add(num);
                        if (list.LastOrDefault().Sequence.Count > maxLength) {
                            maxLength = list.LastOrDefault().Sequence.Count;
                        }
                    }
                    else if (list[i].Sequence.LastOrDefault() > num ) 
                    {
                        list.Add(new theDataStructure() { Sequence = new List<long>(list[i].Sequence), threshold = true });
                        list.LastOrDefault().Sequence.Add(num);
                        if (list.LastOrDefault().Sequence.Count > maxLength)
                        {
                            maxLength = list.LastOrDefault().Sequence.Count;
                        }
                    }
                }
            }
            list.ForEach(x => { x.Sequence.ForEach(y => Console.Write(" " + y)); Console.Write(" threshold:" + x.threshold+"\n"); });

            var maxLengthSubsequence=list.FirstOrDefault(x => x.Sequence.Count() >= maxLength);
            maxLengthSubsequence.Sequence.ForEach(x => Console.Write(" " + x));
            Console.Write(" Length : " + maxLengthSubsequence.Sequence.Count());
            Console.Read();
        }
    }
}
