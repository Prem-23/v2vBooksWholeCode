using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ClsDashCommonDto
    {
        private ClsDashCommonDto()
        {

        }

        private readonly static Lazy<ClsDashCommonDto> objClsDashCommonDto = new Lazy<ClsDashCommonDto>(() => new ClsDashCommonDto());

        public static ClsDashCommonDto GetobjClsDashCommonDto
        {
            get
            {
                return objClsDashCommonDto.Value;
            }
        }

        private string _ddlBkName;

        public string ddlBkName
        {
            get { return _ddlBkName; }
            set { _ddlBkName = value; }
        }

        private int _ddlBkID;

        public int ddlBkID
        {
            get { return _ddlBkID; }
            set { _ddlBkID = value; }
        }

        private int _ddlBkStatus;

        public int ddlBkStatus
        {
            get { return _ddlBkStatus; }
            set { _ddlBkStatus = value; }
        }

        private string _BkName;

        public string BkName
        {
            get { return _BkName; }
            set { _BkName = value; }
        }

        private string _AuthName;

        public string AuthName
        {
            get { return _AuthName; }
            set { _AuthName = value; }
        }

        private string _PubName;

        public string PubName
        {
            get { return _PubName; }
            set { _PubName = value; }
        }

        private int _ddlBkStatusadd;

        public int ddlBkStatusadd
        {
            get { return _ddlBkStatusadd; }
            set { _ddlBkStatusadd = value; }
        }

        private string _BkType;

        public string BkType
        {
            get { return _BkType; }
            set { _BkType = value; }
        }

        private string _BkPrice;

        public string BkPrice
        {
            get { return _BkPrice; }
            set { _BkPrice = value; }
        }

        private int _ddlCartBkStatus;

        public int ddlCartBkStatus
        {
            get { return _ddlCartBkStatus; }
            set { _ddlCartBkStatus = value; }
        }

        private int _NumofStock;

        public int NumofStock
        {
            get { return _NumofStock; }
            set { _NumofStock = value; }
        }

        private string _BkDesc;

        public string BkDesc
        {
            get { return _BkDesc; }
            set { _BkDesc = value; }
        }

        private string _BkImgName;

        public string BkImgName
        {
            get { return _BkImgName; }
            set { _BkImgName = value; }
        }

        private string _BkDisPrice;

        public string BkDisPrice
        {
            get { return _BkDisPrice; }
            set { _BkDisPrice = value; }
        }

        private string _BkDisDesc;

        public string BkDisDesc
        {
            get { return _BkDisDesc; }
            set { _BkDisDesc = value; }
        }
    }
}
