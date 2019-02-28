using System;
using System.Collections.Generic;
using System.Text;

namespace App12.Data
{
    public class Pozorniy
    {
        private List<Object> Obektniy=new List<Object>();
        public void Probitie(Object pomoika)
        {
            Obektniy.Add(pomoika);
            if (pomoika.GetType() == typeof(string))
            {
                Obektniy.Add(pomoika + "!");
            }
            //kakaiato stroxhka
            else if (pomoika.GetType() == typeof(int))
            {
                Obektniy.Add((int)pomoika * 2);
            }
            else if (pomoika.GetType() == typeof(double))
            {
                Obektniy.Add((double)pomoika / 2);
            }
            else if (pomoika.GetType() == typeof(List<>))
            {

                Obektniy.Add(pomoika);
            }
            else
                Console.WriteLine("Est probitie");
        }
        public List<Object> Degenerat(Type type)
        {
            List<Object> Nedonoshen = new List<Object>();
            foreach (var item in Obektniy)
            {
                if (item.GetType() == type)
                {
                    Nedonoshen.Add(item);
                }
                else if (type== typeof(Object))
                {
                    Nedonoshen.Add(item);
                }
            }
            return Nedonoshen;
        }
        static public void asdas (List<Object> list)
            {
            foreach (var item in list)
            {
                if (item.GetType() == typeof(List<>))
                    asdas(item as List<Object>);
                else
                    Console.WriteLine(item +" | "+ item.GetType().ToString());
            }

        }

    }
    
}
