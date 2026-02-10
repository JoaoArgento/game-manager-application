import {QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ComponentProps, useState } from "react";

export default function Providers(props) 
{
    const [queryClient] = useState(() => new QueryClient());

    return <QueryClientProvider client={queryClient}>
        {props.children}
    </QueryClientProvider>
}