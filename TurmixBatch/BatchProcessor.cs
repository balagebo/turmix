using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TurmixLog;
using System.Windows.Forms;
using System.Drawing;

namespace TurmixBatch
{
    public class TmxParser
    {
        private XmlDocument tempDoc = new XmlDocument();
        private CimOsszesito osszesito = new CimOsszesito();



        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public CimOsszesito Osszesito
        {
            get { return osszesito; }
            set { osszesito = value; }
        }
        private List<WorkData> workList = new List<WorkData>();

        public List<WorkData> WorkList
        {
            get { return workList; }
            set { workList = value; }
        }

        private List<Auto> autok = new List<Auto>();

        public List<Auto> Autok
        {
            get { return autok; }
            set { autok = value; }
        }

        public void Parse(string file)
        {
            try
            {
                tempDoc.Load(file);
                date = DateTime.Parse(tempDoc.DocumentElement.Attributes[0].Value);
                if (date < new DateTime(2009, 3, 11))
                {
                    MessageBox.Show("A program jelenleg nem támogatja a 2009.03.11. előtti mentéseket.", "Nem támogatott formátum", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (date < new DateTime(2009, 4, 3))
                {
                    ParseMarcius();
                }
                else if (date < new DateTime(2009, 4, 30))
                {
                    ParseAprilis();
                }
                else
                {
                    ParseUj();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Az állomány megnyitása sikertelen.", "Megnyitás sikertelen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParseMarcius()
        {
            Auto tmpCar;
            WorkData tmpData;
            string tmpRsz = null ;
            try
            {
               
                foreach (XmlNode carNode in tempDoc.GetElementsByTagName("auto"))
                {
                    tmpRsz = carNode.Attributes[0].Value;
                    tmpCar = new Auto(tmpRsz);
                    autok.Add(tmpCar);

                    foreach (XmlNode cimNode in carNode.ChildNodes)
                    {
                        tmpData = new WorkData();
                        tmpData.Datum = date;
                        tmpData.Rendszam = tmpRsz;
                        //tmpData.ParseKoord(cimNode);
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

        private void ParseAprilis()
        {
            Auto tmpCar;
            WorkData tmpData;
            string tmpRsz = null;
            try
            {
                
                foreach (XmlNode carNode in tempDoc.DocumentElement.FirstChild.ChildNodes)
                {
                    tmpRsz = carNode.Attributes[0].Value;
                    tmpCar = new Auto(tmpRsz);
                    tmpCar.Index = int.Parse(carNode.Attributes[6].Value);
                    autok.Add(tmpCar);
                }
                foreach (XmlNode cimNode in tempDoc.DocumentElement.ChildNodes[1].ChildNodes)
                {
                    tmpData = new WorkData();
                    tmpData.Datum = date;
                    tmpData.Rendszam = tmpRsz;
                    //tmpData.ParseKoord(cimNode);
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

        private void ParseUj()
        {
            Auto tmpCar;
            WorkData tmpData;
            List<WorkData> tmpFordulo = new List<WorkData>();
            string tmpRsz;
            int tmpTav;
            try
            {
                
                foreach (XmlNode carNode in tempDoc.DocumentElement.FirstChild.ChildNodes)
                {
                    tmpRsz = carNode.Attributes[0].Value;

                    tmpCar = new Auto(tmpRsz);
                    autok.Add(tmpCar);

                    foreach (XmlNode fordNode in carNode.ChildNodes)
                    {
                        tmpTav = int.Parse(fordNode.Attributes[0].Value);   
                        tmpFordulo.Clear();

                        foreach (XmlNode cimNode in fordNode.ChildNodes)
                        {
                            tmpData = new WorkData();
                            //tmpData.ParseKoord(cimNode);
                            tmpData.Rendszam = tmpRsz;
                            tmpData.Datum = date;
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
            foreach (Auto a in autok)
            {
                if (a.Index == p)
                    return a;
            }
            return null;
        }

        
    }
}
