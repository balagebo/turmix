using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TurmixLog
{
    public class BatchProcessor
    {
        private XmlDocument tempDoc = new XmlDocument();
        private CimOsszesito osszesito = new CimOsszesito();
        private List<WorkData> workList = new List<WorkData>();

        private Dictionary<string, Auto> autok = new Dictionary<string, Auto>();

        private string pathRoot;

        public void ParseMarcius(DateTime date)
        {
            Auto tmpCar;
            WorkData tmpData;
            string tmpRsz;
            try
            {
                tempDoc.Load(string.Format("{0}\\{1}.tmx", pathRoot, date.ToString("yyyy_MM_dd")));
                foreach (XmlNode carNode in tempDoc.GetElementsByTagName("auto"))
                {
                    tmpRsz = carNode.Attributes[0].Value;
                    tmpCar = new Auto(tmpRsz);
                    autok.Add(tmpRsz, tmpCar);

                    foreach (XmlNode cimNode in carNode.ChildNodes)
                    {
                        tmpData = new WorkData();
                        tmpData.Lat = double.Parse(cimNode.Attributes[0].Value);
                        tmpData.Lng = double.Parse(cimNode.Attributes[1].Value);
                        tmpData.WorkCapacity = int.Parse(cimNode.Attributes[2].Value);
                        tmpData.TenylegesKobmeter = int.Parse(cimNode.Attributes[3].Value);
                        tmpData.Napszak = int.Parse(cimNode.Attributes[4].Value);
                        tmpData.Utca = cimNode.Attributes[6].Value;
                        tmpData.HazSzam = cimNode.Attributes[7].Value;
                        tmpData.IranyitoSzam = int.Parse(cimNode.Attributes[8].Value);
                        tmpData.CsoHossz = int.Parse(cimNode.Attributes[9].Value);
                        tmpData.WorksheetNumber = long.Parse(cimNode.Attributes[10].Value);

                        osszesito.UpdateWith(tmpData);

                        tmpCar.AddFuvar(tmpData, int.Parse(cimNode.Attributes[13].Value));

                        workList.Add(tmpData);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        public void ParseAprilis(DateTime date)
        {
            Auto tmpCar;
            WorkData tmpData;
            string tmpRsz;
            try
            {
                tempDoc.Load(string.Format("{0}\\{1}.tmx", pathRoot, date.ToString("yyyy_MM_dd")));
                foreach (XmlNode carNode in tempDoc.DocumentElement.FirstChild.ChildNodes)
                {
                    tmpRsz = carNode.Attributes[0].Value;
                    tmpCar = new Auto(tmpRsz);
                    tmpCar.Index = int.Parse(carNode.Attributes[6].Value);
                    autok.Add(tmpRsz, tmpCar);
                }
                foreach (XmlNode cimNode in tempDoc.DocumentElement.ChildNodes[1].ChildNodes)
                {
                    tmpData = new WorkData();
                    tmpData.Lat = double.Parse(cimNode.Attributes[0].Value);
                    tmpData.Lng = double.Parse(cimNode.Attributes[1].Value);
                    tmpData.WorkCapacity = int.Parse(cimNode.Attributes[2].Value);
                    tmpData.TenylegesKobmeter = int.Parse(cimNode.Attributes[3].Value);
                    tmpData.Napszak = int.Parse(cimNode.Attributes[4].Value);
                    tmpData.Utca = cimNode.Attributes[6].Value;
                    tmpData.HazSzam = cimNode.Attributes[7].Value;
                    tmpData.IranyitoSzam = int.Parse(cimNode.Attributes[8].Value);
                    tmpData.CsoHossz = int.Parse(cimNode.Attributes[9].Value);
                    tmpData.WorksheetNumber = long.Parse(cimNode.Attributes[10].Value);

                    osszesito.UpdateWith(tmpData);

                    tmpCar = FindByIndex(int.Parse(cimNode.Attributes[12].Value));
                    tmpCar.AddFuvar(tmpData, int.Parse(cimNode.Attributes[14].Value));
                    workList.Add(tmpData);
                }

            }
            catch (Exception e) 
            {
            }
        }

        public void ParseUj(DateTime date)
        {
            Auto tmpCar;
            WorkData tmpData;
            List<WorkData> tmpFordulo = new List<WorkData>();
            string tmpRsz;
            int tmpTav;
            try
            {
                tempDoc.Load(string.Format("{0}\\{1}.tmx", pathRoot, date.ToString("yyyy_MM_dd")));
                foreach (XmlNode carNode in tempDoc.DocumentElement.FirstChild.ChildNodes)
                {
                    tmpRsz = carNode.Attributes[0].Value;

                    tmpCar = new Auto(tmpRsz);
                    autok.Add(tmpRsz, tmpCar);

                    foreach (XmlNode fordNode in carNode.ChildNodes)
                    {
                        tmpTav = int.Parse(fordNode.Attributes[0].Value);
                        tmpFordulo.Clear();

                        foreach (XmlNode cimNode in fordNode.ChildNodes)
                        {
                            tmpData = new WorkData();
                            tmpData.Lat = double.Parse(cimNode.Attributes[0].Value);
                            tmpData.Lng = double.Parse(cimNode.Attributes[1].Value);
                            tmpData.WorkCapacity = int.Parse(cimNode.Attributes[2].Value);
                            tmpData.TenylegesKobmeter = int.Parse(cimNode.Attributes[3].Value);
                            tmpData.Napszak = int.Parse(cimNode.Attributes[4].Value);
                            tmpData.Utca = cimNode.Attributes[6].Value;
                            tmpData.HazSzam = cimNode.Attributes[7].Value;
                            tmpData.IranyitoSzam = int.Parse(cimNode.Attributes[8].Value);
                            tmpData.CsoHossz = int.Parse(cimNode.Attributes[9].Value);
                            tmpData.WorksheetNumber = long.Parse(cimNode.Attributes[10].Value);

                            osszesito.UpdateWith(tmpData);

                            tmpFordulo.Add(tmpData);
                            workList.Add(tmpData);

                        }
                        tmpCar.AddFuvar(tmpFordulo, tmpTav);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        private Auto FindByIndex(int p)
        {
            foreach (Auto a in autok.Values)
            {
                if (a.Index == p)
                    return a;
            }
            return null;
        }
    }
}
