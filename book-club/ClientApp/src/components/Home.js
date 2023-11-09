import React from 'react';

export function Home() {
  let imageSrc = "https://prodimage.images-bn.com/lf?set=key%5Bresolve.pixelRatio%5D,value%5B1%5D&set=key%5Bresolve.width%5D,value%5B300%5D&set=key%5Bresolve.height%5D,value%5B10000%5D&set=key%5Bresolve.imageFit%5D,value%5Bcontainerwidth%5D&set=key%5Bresolve.allowImageUpscaling%5D,value%5B0%5D&set=key%5Bresolve.format%5D,value%5Bwebp%5D&source=url%5Bhttps://prodimage.images-bn.com/pimages/9780425266540_p0_v6_s600x595.jpg%5D&scale=options%5Blimit%5D,size%5B300x10000%5D&sink=format%5Bwebp%5D" 
  
  return(
    <div className='bg-indigo-500 h-screen grid items-center justify-center max-h-screen gap-2'>
      <img className='justify-self-center' src={imageSrc}></img>
      <h1 className='justify-self-center text-4xl'>TitleGoesHere</h1>
      <h2 className='justify-self-center text-3xl'>AuthorGoesHere</h2>
      <h3 className='justify-self-center text-xl'>Next Meeting: PopulateDateHere</h3>
      <h3 className='justify-self-center text-xl'>Host: HostNameGoesHere</h3>
      <h3 className='justify-self-center text-xl pb-20'>Location: 1234 PutAddress Here, City 12345</h3>
    </div>
  )
}