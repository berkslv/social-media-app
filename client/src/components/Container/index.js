import React from 'react'

function Container({ children }) {
  return (
    <div className="container py-3">
        {children}
    </div>
  )
}

export default Container