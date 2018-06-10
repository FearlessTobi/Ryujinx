using Ryujinx.Core.Input;
using Ryujinx.Core.Logging;
using Ryujinx.Core.OsHle.Ipc;
using System.Collections.Generic;
using Ryujinx.Core.OsHle.Handles;

namespace Ryujinx.Core.OsHle.Services.Hid
{
    class IIrSensorServer : IpcService
    {
        private Dictionary<int, ServiceProcessRequest> m_Commands;

        public override IReadOnlyDictionary<int, ServiceProcessRequest> Commands => m_Commands;

        private HSharedMem IrSensorSharedMem;
        
        public IIrSensorServer(HSharedMem IrSensorSharedMem)
        {
            m_Commands = new Dictionary<int, ServiceProcessRequest>()
            {
                { 302,   ActivateIrsensor                 },
                { 303,   DeactivateIrsensor               },
                { 304,   GetIrsensorSharedMemoryHandle    },
                { 311,   GetNpadIrCameraHandle            }
            };
            
            this.IrSensorSharedMem = IrSensorSharedMem;
        }

        public long ActivateIrsensor(ServiceCtx Context)
        {
            Context.Ns.Log.PrintStub(LogClass.ServiceHid, "Stubbed.");

            return 0;
        }
        
        public long DeactivateIrsensor(ServiceCtx Context)
        {
            Context.Ns.Log.PrintStub(LogClass.ServiceHid, "Stubbed.");

            return 0;
        }
        
        public long GetIrsensorSharedMemoryHandle(ServiceCtx Context)
        {
            int Handle = Context.Process.HandleTable.OpenHandle(IrSensorSharedMem);

            Context.Response.HandleDesc = IpcHandleDesc.MakeCopy(Handle);
            
            Context.Ns.Log.PrintStub(LogClass.ServiceHid, "Stubbed.");

            return 0;
        }

        public long GetNpadIrCameraHandle(ServiceCtx Context)
        {
            Context.Ns.Log.PrintStub(LogClass.ServiceHid, "Stubbed.");
            
            int Handle = Context.RequestData.ReadInt32();
            
            Context.ResponseData.Write(Handle);

            return 0;
        }
        
    }
}
