import  {UseMutationResult } from "@tanstack/react-query"
import { CreateGameDTO, GameDTO } from "./GameDTO"

export type GameFormsProps = 
{
    title: string,
    description: string,
    confirmText: string
    onConfirm: (payload: CreateGameDTO, onSuccess: () => void) => void
    onCancel: () => void;
}