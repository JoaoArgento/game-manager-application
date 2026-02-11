import { X } from "lucide-react";

type ConfirmModalProps =
{
    title: string
    description: string
    isOpen: boolean
    onConfirm: () => void
    onCancel: () => void

}

export default function ConfirmModel(props : ConfirmModalProps)
{

    if (!props.isOpen)
    {
        return <></>;
    }

    return (
        <div className = "fixed inset-0 z-50 flex items-center justify-center bg-black/50 backdrop-blur-sm p-4">
            <div className = "w-full max-w-md overflow-hidden rounded-xl bg-white shadow-xl ring-1 ring-zinc-200">
                <div className="flex items-center justify-between border-b border-zinc-100 p-4">
                    <div>
                        <h3 className = "font-semibold text-zinc-900">{props.title}</h3>
                    </div>
                    <button onClick = {props.onCancel} className = "text-zinc-400 hover:text-zinc-600">
                        <X className="h-5 w-5"/>
                    </button>
                </div>
            <div className = "p-4">
                <p className = "text-sm text-zinc-600">
                    {props.description}
                </p>
            </div>

            <div className = "flex justify-end gap-3 bg-zinc-50 p-4">
                <button onClick={props.onCancel}
                        className = "rounded-lg border border-zinc-200 bg-white px-4 py-2 text-sm font-medium text-zinc-700 hover:bg-zinc-50 disabled:opacity-50">
                    Cancelar
                </button>
                <button onClick={props.onConfirm}
                className = "rounded-lg bg-red-600 px-4 py-2 text-sm font-medium text-white hover:bg-red-700 disabled: opacity-50">
                    Confirmar
                </button>
            </div>
        </div>
    </div>
    )
}