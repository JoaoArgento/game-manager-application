type ConfirmModalProps =
{
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
        <div>
            <p>TEM CERTEZA DISSO PAIZAO?</p>
            <button onClick = {props.onConfirm}>SIM</button>
            <button onClick = {props.onCancel}>NÃO</button>
        </div>
    )
}