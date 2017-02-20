namespace Common.Model.Base
{
    /// <summary>
    /// Is used for inheritence to other view models. Alert is used to alert a view.
    /// </summary>
    public class BaseModel
    {
        private string _alert = null;

        public void PushAlert(string alertView)
        {
            _alert = alertView;
        }

        public string PopAlert()
        {
            string temp = _alert;
            _alert = null;
            return temp;
        }

        public bool IsAlerted()
        {
            return (_alert != null ? true : false);
        }
    }
}
