using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CommonDto
    {
        private CommonDto()
        {

        }

        private static readonly Lazy<CommonDto> objCommonDto = new Lazy<CommonDto>(() => new CommonDto());

        public static CommonDto GetobjCommonDto
        {
            get
            {
                return objCommonDto.Value;
            }
        }

        private string _fstName;

        public string fstName
        {
            get { return _fstName; }
            set { _fstName = value; }
        }

        private string _lstName;

        public string lstName
        {
            get { return _lstName; }
            set { _lstName = value; }
        }

        private string _mdlName;

        public string mdlName
        {
            get { return _mdlName; }
            set { _mdlName = value; }
        }

        private string _mobNum;

        public string mobNum
        {
            get { return _mobNum; }
            set { _mobNum = value; }
        }

        private string _alternateMobNum;

        public string alternateMobNum
        {
            get { return _alternateMobNum; }
            set { _alternateMobNum = value; }
        }

        private string _addOne;

        public string addOne
        {
            get { return _addOne; }
            set { _addOne = value; }
        }

        private string _addTwo;

        public string addTwo
        {
            get { return _addTwo; }
            set { _addTwo = value; }
        }

        private string _state;

        public string state
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _city;

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _pin;

        public string pin
        {
            get { return _pin; }
            set { _pin = value; }
        }

        private string _country;

        public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _quan;

        public string quan
        {
            get { return _quan; }
            set { _quan = value; }
        }

        private string _mailID;

        public string mailID
        {
            get { return _mailID; }
            set { _mailID = value; }
        }

        private string _Dist;

        public string Dist
        {
            get { return _Dist; }
            set { _Dist = value; }
        }

        private Int32 _BookID;

        public Int32 BookID
        {
            get { return _BookID; }
            set { _BookID = value; }
        }

        private Int32 _userInsertID;

        public Int32 userInsertID
        {
            get { return _userInsertID; }
            set { _userInsertID = value; }
        }

        private Int16 _sentStatus;
        public Int16 sentStatus
        {
            get { return _sentStatus; }
            set { _sentStatus = value; }
        }

        private string _sentThrough;
        public string sentThrough
        {
            get { return _sentThrough; }
            set { _sentThrough = value; }
        }

        private Int16 _isValidStatus;
        public Int16 isValidStatus
        {
            get { return _isValidStatus; }
            set { _isValidStatus = value; }
        }
    }
}
