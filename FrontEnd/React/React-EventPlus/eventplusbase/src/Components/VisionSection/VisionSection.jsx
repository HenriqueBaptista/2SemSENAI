import React from 'react';
import './VisionSection.css'
import Title from '../Title/Title'

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>
                <Title
                    titleText={"Visao"}
                    color='white'
                    additionalClass='vision__title' />

                <p className='vision__text'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laudantium molestiae mollitia totam voluptatum! Minus, repudiandae optio. Quisquam veritatis ex incidunt architecto similique voluptatum vitae quasi, fugit consectetur, beatae quas eveniet.</p>
            </div>
        </section>
    );
};

export default VisionSection;