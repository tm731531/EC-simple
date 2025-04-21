-- 📦 platform
CREATE TABLE platform (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    code VARCHAR(20) NOT NULL UNIQUE,
    created_at TIMESTAMP NOT NULL DEFAULT NOW()
);

-- 📦 channel
CREATE TABLE channel (
    id SERIAL PRIMARY KEY,
    platform_id INT NOT NULL,
    name VARCHAR(50) NOT NULL,
    code VARCHAR(20) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    CONSTRAINT fk_channel_platform FOREIGN KEY (platform_id) REFERENCES platform(id)
);
CREATE UNIQUE INDEX idx_channel_code_platform ON channel (platform_id, code);

-- 📦 product
CREATE TABLE product (
    id SERIAL PRIMARY KEY,
    sku VARCHAR(30) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    created_at TIMESTAMP NOT NULL DEFAULT NOW()
);

-- 📦 sellpack
CREATE TABLE sellpack (
    id SERIAL PRIMARY KEY,
    product_id INT NOT NULL,
    code VARCHAR(30) NOT NULL UNIQUE,
    pack_name VARCHAR(50) NOT NULL,
    price NUMERIC(10,2) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    CONSTRAINT fk_sellpack_product FOREIGN KEY (product_id) REFERENCES product(id)
);

-- 📦 order（主表，用 order_date 做範圍分區）
CREATE TABLE order_main (
    id SERIAL NOT NULL,
    order_no VARCHAR(40) NOT NULL,
    channel_id INT NOT NULL,
    sellpack_id INT NOT NULL,
    quantity INT NOT NULL,
    total_amount NUMERIC(12,2) NOT NULL,
    order_date DATE NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    PRIMARY KEY (id),
    CONSTRAINT fk_order_channel FOREIGN KEY (channel_id) REFERENCES channel(id),
    CONSTRAINT fk_order_sellpack FOREIGN KEY (sellpack_id) REFERENCES sellpack(id)
) PARTITION BY RANGE (order_date);

-- 📦 範例分區：order_2025_q1
CREATE TABLE order_2025_q1 PARTITION OF order_main
FOR VALUES FROM ('2025-01-01') TO ('2025-04-01');

-- 📦 範例索引（可用於所有分區）
CREATE INDEX idx_order_order_no ON order_main (order_no);
CREATE INDEX idx_order_order_date ON order_main (order_date);
CREATE INDEX idx_order_channel_id ON order_main (channel_id);
CREATE INDEX idx_order_sellpack_id ON order_main (sellpack_id);
