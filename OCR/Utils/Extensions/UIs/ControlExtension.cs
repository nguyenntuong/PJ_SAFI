using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR.Utils.Extensions.UIs
{
    public static class ControlExtension
    {
        // <summary>
        /// Chạy các tác vụ liên quan để chỉnh sữa UI từ các luồn phụ không phải luồn chính
        /// Chạy đồng bộ ngay lập tức
        /// </summary>
        /// <param name="action"></param>
        public static void InvokeOnUIThreadSync(this Control ctr, Action action)
        {
            ctr?.Invoke(action);
        }
        // <summary>
        /// Chạy các tác vụ liên quan để chỉnh sữa UI từ các luồn phụ không phải luồn chính
        /// Chạy đồng bộ ngay lập tức
        /// </summary>
        /// <param name="action"></param>
        public static void InvokeOnUIThreadASync(this Control ctr, Action action)
        {
            ctr?.EndInvoke(ctr?.BeginInvoke(action));
        }
    }
}
