import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import "./style/reset.scss"
import Root from './root';
import Home from './Pages/home/Home';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root/>,
    children: [
      {
        path: "/",
        element: <Home/>
      },
      {
        path: "/experience",
      },
      {
        path: "/education"
      },
      {
        path: "/projects"
      },
      {
        path: "/About"
      }
    ]
  },
]); 

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
)
