"use client"

import "../styles/globals.css";
import Providers from "./providers";


export default function RootLayout(props)
{
    return<html>
        <body>
            <h1 className="text-3xl bold">O pai ta on</h1>
            <Providers>
                {props.children}
            </Providers>
        </body>
    </html> 
    
} 