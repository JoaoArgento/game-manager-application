import { useState } from "react"

export default function GameForms(props)
{

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [logoPath, setLogoPath] = useState("");

    function onSubmit(event)
    {
        event.preventDefault();

        let payload = {
            name: name,
            description: description,
            logoPath: logoPath,
        }
        props.createGame.mutate(payload, {
            onSuccess: () =>
            {
                setName("");
                setDescription("");
                setLogoPath("");
            }
        })
    }

    return (
    <div className = "h-fit overflow-hidden rounded-xl border border-zinc-200 bg-white shadow-sm">
        <div className = "border-b border-zinc-100 bg-zinc-50/50 p-4">
            <h3 className = "text-lg font-semibold text-zinc-900">Novo jogo</h3>
            <p className = "text-sm text-zinc-500">Preencha os dados</p>
        </div>
        <form onSubmit={onSubmit} className = "flex flex-col gap-4 p-4">
            <div className="flex flex-col gap-1.5">
                <label className = "text-sm font-medium text-zinc-700">
                    Nome
                </label>
                <input type = "text"
                value = {name}
                onChange={(e) => setName(e.target.value)}
                placeholder = "Digite o nome do jogo"
                required
                className = "w-full rounded-lg border border-zinc-200 px-3 py-2 text-sm text-zinc-800 placeholder:text-zinc-400 focus:border-zinc-400 focus: outline-none focus:ring-2  focus: ring-zinc-400/20"
                />
                
            </div>

            <div className ="flex flex-col gap-1.5">
                <label>Descrição </label>
                <textarea
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required
                className = "w-full resize-none rounded-lg border border-zinc-200 px-3 py-2 text-sm text-zinc-800 placeholder:text-zinc-400 focus:border-zinc-400 focus:outline-none focus:ring-2 focus:ring-zinc-400/20">
                </textarea>
            </div>

            
            <div className = "flex flex-col gap-1.5">
                <label>URL da Imagem </label>
                <input type = "text"
                value={logoPath}
                onChange={(e) => setLogoPath(e.target.value)}
                required
                className = "w-full rounded-lg border border-zinc-200 px-3 py-2 text-sm text-zinc-800 placeholder:text-zinc-400 focus:border-zinc-400 focus: outline-none focus:ring-2  focus: ring-zinc-400/20"/>
                
            </div>

            <button
            className = "inline-flex w-full items-center justify-center gap-2 rounded-lg bg-zinc-900 px-4 py-2.5 text-sm font-semibold text-white shadow-sm transition hover:bg-zinc-800 focus:outline-none focus:ring-2 focus:ring-zinc-900 focus:ring-offset-2 disabled:opacity-50 disabled:cursor-not-allowed" 
            type = "submit" disabled = {props.createGame.isPending}>
                {props.createGame.isPending ? "Carregando..." : "Criar jogo"} 
            </button>   
        </form>
    </div>
    )
}